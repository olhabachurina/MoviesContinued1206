using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesContinued1206.Models;


namespace MoviesContinued1206.Controllers
{
    
    public class MoviesController : Controller
    {
        private readonly MovieContext _context; 

       
        public MoviesController(MovieContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            
            return View(await _context.Movies.ToListAsync());
        }

       
        public async Task<IActionResult> Details(int? id)
        {
            
            if (id == null)
            {
                return NotFound(); 
            }

           
            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.Id == id);
           
            if (movie == null)
            {
                return NotFound(); 
            }

           
            return View(movie);
        }

        

        
        public async Task<IActionResult> Delete(int? id)
        {
            
            if (id == null)
            {
                return NotFound(); 
            }

           
            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (movie == null)
            {
                return NotFound(); 
            }

            return View(movie); 
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound(); 
            }

            _context.Movies.Remove(movie); 
            await _context.SaveChangesAsync(); 
            return RedirectToAction(nameof(Index)); 
        }

        
        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.Id == id);
        }
    }
}
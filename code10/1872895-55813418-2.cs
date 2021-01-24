    public class ParentsController : Controller
    {
        private readonly TestDbContext _context;
        public ParentsController(TestDbContext context)
        {
            _context = context;
        }        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var parent = await _context.Parent
                .Include(x=>x.Child1s).ThenInclude(x=>x.Child2s)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parent == null)
            {
                return NotFound();
            }
            return View(parent);
        }
    }

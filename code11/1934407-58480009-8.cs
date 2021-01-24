    public class CategoryController : Controller
        {
            private ApplicationDbContext _context;
    
            public CategoryController()
            {
                _context = new ApplicationDbContext();
            }
    
            [HttpGet]
            public ActionResult CreateCategory()
            {
                ViewBag.Categories = GetCategories();
                return View();
            }
    
            private IEnumerable<SelectListItem> GetCategories()
            {
                var categories = _context.CategoryModels
                    .Select(c => new SelectListItem
                    {
                        Value = c.ID.ToString(),
                        Text = c.Value
                    });
    
                return categories;
            }
        }

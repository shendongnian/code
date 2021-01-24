    public class MyController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IMemoryCache _cache;
       
        public MyController(ApplicationDbContext context, IMemoryCache memoryCache)
        {
            _context = context;
            _cache = memoryCache;
        }
        
        public IActionResult Create()
        {           
            var types = _context.Types.AsNoTracking().ToList();
    
            var vm = new EventViewModel
            {
                Types = new SelectList(types, "Id", "Name")
            };
            _cache.Set("types",types);//cache data
            return View(vm);
        }
       
        [HttpPost]
        public IActionResult Create(EventViewModel vm)
        {
            if (!ModelState.IsValid)
            {
               var types = _cache.Get<List<Type>>("types");//get cached data
               vm.Types = new SelectList(types, "Id", "Name", vm.TypeId);
               return View(vm);
            }
           
            return RedirectToAction("Index", "Home");
        }
    }

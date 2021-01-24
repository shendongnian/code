    public class TestModelsController : Controller
    {
        private readonly MyDbContext _context;
        public TestModelsController(MyDbContext context)
        {
            _context = context;
        }
        // GET: TestModels
        public async Task<IActionResult> Index()
        {
            var model = await _context.TestModel.ToListAsync();
            return View(model);
        }
    }

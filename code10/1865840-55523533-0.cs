    [Route("[controller]")]
    public abstract class BaseProductController<TProduct, TProductModel> : Controller
        where TProduct : Product, new()
        where TProductModel : ProductModel, new()
    {
        protected readonly ApplicationDbContext _context;
        protected readonly IMapper _mapper;
        protected BaseProductController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet("create")]
        public IActionResult Create()
        {
            return View(new ProductModel());
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(TProductModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var product = _mapper.Map<TProduct>(model);
            _context.Add(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        // etc.
    }
    

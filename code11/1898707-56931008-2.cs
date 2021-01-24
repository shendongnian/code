    private readonly RazorPages2_1Project.Data.RazorPagesDbContext _context;
        private readonly List<Category> list;
        public CreateModel(RazorPages2_1Project.Data.RazorPagesDbContext context)
        {
            _context = context;
            list = _context.Category.ToList();
        }
        public IActionResult OnGet()
        {
            CategoryList = GetAllCategoryForSearchClients();
            return Page();
        }
        [BindProperty]
        public List<vmCategoryForSearch> CategoryList { get; set; }
        public List<vmCategoryForSearch> GetAllCategoryForSearchClients()
        {
            var result= list.Where(mm => mm.ParentId == 0).Select(m => new vmCategoryForSearch
            {
                Name = m.Name,
                Children = GetAllCategoryForSearchClients(m.Id)
            }).ToList();
            return result;
        }
        private List<vmCategoryForSearch> GetAllCategoryForSearchClients(int id)
        {
            var result1 = list.Where(sm => sm.ParentId == id).Select(vm => new vmCategoryForSearch
            {
                Name = vm.Name,
                Children = GetAllCategoryForSearchClients(vm.Id)
            }).ToList();
            return result1;
        }
    }

    public class IndexModel: PageModel
    {       
        private readonly ApplicationDbContext _context;
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }
        //public ApplicationUser AspNetUser { get; set; }
        public IList<MyView> MyView { get; set; }
        
        public async Task OnGetAsync()
        {
            MyView = await _context.MyViews
                    .Include(s => s.User).ToListAsync();
        }
    }

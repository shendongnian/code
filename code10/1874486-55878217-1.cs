    public class ViewMenuModel : PageModel
    {
        private readonly Servix2DbContext _context;  
        
        public ViewMenuModel(Servix2DbContext context)
        {
            _context = context;
        }
        public List<MenuModel> Menu { get; set; }
        public async Task OnGetAsync()
        {
            Menu =  await _context.Menu.AsNoTracking().ToListAsync();
        }
    }

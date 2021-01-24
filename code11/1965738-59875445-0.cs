    public class HomeModel : PageModel
    { 
        private readonly SecurityCoreContext _context;
        public HomeModel(SecurityCoreContext context)
        {
            _context = context;
        }
        public List<string> OfficerLists { get; set; }
        public IList<SecurityLog> SecurityLog { get; set; }
        public async Task<IActionResult> OnGetAsync()
         {
            OfficerList officerList = new OfficerList();
            OfficerLists = officerList.GetOfficerList(_context);
            SecurityLog = await _context.SecurityLog.AsNoTracking().ToListAsync();
            return Page();
        }
    }

    public class IndexModel : PageModel
    {
        private readonly RazorPages2_1Project.Data.RazorPagesDbContext _context;
        public IndexModel(RazorPages2_1Project.Data.RazorPagesDbContext context)
        {
            _context = context;
        }
        public IList<ExcelData> ExcelData { get;set; }
        public async Task OnGetAsync()
        {
            ExcelData = await _context.ExcelData.ToListAsync();
        }
        public async Task<IActionResult> OnPostAsync([FromBody]string CommaSeparatedIDs)
        {
           //stuff you want
        }
    }

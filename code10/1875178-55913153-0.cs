        public class IndexModel : PageModel
        {
            private readonly TestRazor.Data.ApplicationDbContext _context;
            public IndexModel(TestRazor.Data.ApplicationDbContext context)
            {
                _context = context;
            }
            [BindProperty]
            public IList<DenniPlan2> DenniPlan2 { get;set; }
            public async Task OnGetAsync()
            {
                DenniPlan2 = await _context.DenniPlan2s.Take(3).ToListAsync();
            }
            public async Task<IActionResult> OnPostAsync()
            {
                var r = DenniPlan2;
                return RedirectToPage("./Index");
            }
        }

     public class Query1Model : PageModel
    {
        private readonly RazorPageDbContext _context;
        public Query1Model(RazorPageDbContext context)
        {
            _context = context;
        }
        public IList<Car> CarID { get; set; }
        public List<SelectListItem> Options { get; set; }
        [BindProperty(SupportsGet =true)]
        public int SearchCarID { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            Options = _context.Cars.Select(a =>
                                 new SelectListItem
                                 {
                                     Value = a.CarID.ToString(),
                                     Text = a.CarID.ToString()
                                 }).ToList();
            if (SearchCarID != 0)
            {
                var CarQuery = (from s in _context.Cars
                                where s.CarID == SearchCarID
                                select s);
                CarID = await CarQuery.ToListAsync();
            }
            else
            {
                CarID = await _context.Cars.ToListAsync();
            }
            return Page();
        }
     }

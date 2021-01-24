    public class CreateModel : PageModel
    {
        private readonly ApplicationContext _context;
        private readonly IMapper _mapper;
        public CreateModel(ApplicationContext  context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        [BindProperty]
        public MovieViewModel MovieVM { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Movie movie = _mapper.Map<Movie>(MovieVM);
            _context.Movie.Add(movie);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }

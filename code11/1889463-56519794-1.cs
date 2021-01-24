    public class TestInputModel : PageModel
    {
        //using your db context by DI
        private readonly MyApplicationDbContext _context;
        public TestInputModel(MyApplicationDbContext context)
        {
            _context = context;
        }
        //bind your all inputs' values
        [BindProperty]
        public List<string> MyAllInputs{ get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            //logic to save you input values to dbcontext
            var data = MyAllInputs;
            //...
        }
    }

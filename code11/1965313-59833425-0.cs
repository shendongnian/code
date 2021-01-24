     public class  NewJobModel : PageModel
    {
        private readonly PHDTestWorkScreenContext _context;
        public ContactModel(PHDTestWorkScreenContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
            
            var test = _context...
       }
    }
    //make sure to update your startup cs so you can use DI
    services.AddRazorPages();
        services.AddDbContext<PHDTestWorkScreenContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("Your Connection String Namefrom the config file")));

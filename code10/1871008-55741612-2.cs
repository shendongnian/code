    public class HomeController : Controller
    {
        private readonly IHostingEnvironment _hostingEnv;
        private readonly ApplicationDbContext _context;
        public HomeController(IHostingEnvironment hostingEnv,ApplicationDbContext context)
        {
            _hostingEnv = hostingEnv;
            _context = context;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(EngineerVM engineerVM)
        {
            if (engineerVM.File != null)
            {
                //upload files to wwwroot
                var fileName = Path.GetFileName(engineerVM.File.FileName);
                //judge if it is pdf file
                string ext =Path.GetExtension(engineerVM.File.FileName);
                if(ext.ToLower() != ".pdf")
                {
                    return View();
                }
                var filePath = Path.Combine(_hostingEnv.WebRootPath, "images", fileName);
                using (var fileSteam = new FileStream(filePath, FileMode.Create))
                {
                    await engineerVM.File.CopyToAsync(fileSteam);
                }
                //your logic to save filePath to database, for example
              
                Engineer engineer = new Engineer();
                engineer.Name = engineerVM.Name;
                engineer.FilePath = filePath;
               
                _context.Engineers.Add(engineer);
                await _context.SaveChangesAsync();
            }
            else
            {
            }
            return View();
        }
    }

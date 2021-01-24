     [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IHostingEnvironment _hostingEnv;
        private readonly WebAPIDbContext _context;
        
        public CarsController(WebAPIDbContext context, IHostingEnvironment hostingEnv)
        {
            _hostingEnv = hostingEnv;
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromForm] CarViewModel carVM)
        {
            if (carVM.Image != null)
            {
                var a = _hostingEnv.WebRootPath;
                var fileName = Path.GetFileName(carVM.Image.FileName);
                var filePath = Path.Combine(_hostingEnv.WebRootPath, "images\\Cars", fileName);
                using (var fileSteam = new FileStream(filePath, FileMode.Create))
                {
                    await carVM.Image.CopyToAsync(fileSteam);
                }
                
                Car car = new Car();
                car.CarName = carVM.CarName;
                car.ImagePath = filePath;  //save the filePath to database ImagePath field.
                _context.Add(car);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }

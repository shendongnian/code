    [ApiController]
    [Route("/")]
    public class WeatherForecastController : ControllerBase
    {
      DataContext _context;
      static int counter = 0;
      public WeatherForecastController(DataContext context){
        _context = context;
      }
      [HttpGet]
      public string Get()
      {
        counter++; 
      }
      [HttpPost("UploadFile")]
      public async Task UploadFile()
      {
        counter++;
      }
    }

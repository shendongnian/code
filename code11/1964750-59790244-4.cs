    [ApiController]
    [Route("[controller]/[action]")] //<-- NOTE THIS
    public class WeatherForecastController : ControllerBase {
        //...
        //GET weatherforecast/get
        [HttpGet]
        public IEnumerable<WeatherForecast> Get() {
            //...
        }
        //GET weatherforecast/grab
        [HttpGet]
        public IEnumerable<WeatherForecast> Grab() {
            //...
        }
        //GET weatherforecast/Snatch/1
        [HttpGet("{i:int}")]
        public IEnumerable<WeatherForecast> Snatch(int i) {
            //...
        }
    }

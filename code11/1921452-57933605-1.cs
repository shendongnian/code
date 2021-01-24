    [Route("api/[controller]")]
        [ApiController]
        public class SearchController : ControllerBase
        {
            
        [HttpGet("{company}")]
        public IActionResult Get(string company) {
            return Ok($"company: {company}");
        }
        [HttpGet("{country}/{program}")]
        public IActionResult Get(string country, string program) {
            return Ok($"country: {country} program: {program}");
        }
       }

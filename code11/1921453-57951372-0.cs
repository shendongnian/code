    [Route("[controller]")]
    public class SearchController : Controller
    {
        [HttpGet("[action]")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("{company}")]
        public IActionResult Get(string company)
        {
            return Ok($"company: {company}");
        }
        [HttpGet("{country}/{program}")]
        public IActionResult Get(string country, string program)
        {
            return Ok($"country: {country} program: {program}");
        }
    }

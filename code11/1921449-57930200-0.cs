    [Route("Search")]
    public class SearchController : Controller
    {
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
}

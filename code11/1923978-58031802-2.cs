    [Route("api")]
    [ApiController]
    public class CountryController : Controller
    {
        private ICountryRepository countryRepository;
        public CountryController(ICountryRepository repository)
        {
            this.countryRepository = repository;
        }
        [HttpGet("country")]
        public IActionResult GetCountries()
        {
            var countries = countryRepository.GetCountries().ToList();
            return Ok(countries);
        }
     }

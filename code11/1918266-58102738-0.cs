    public class ValuesController : ApiController
    {
        private string[] cities = { "pune", "Mumbai" }; // cities is now an array of string
        // GET api/values
        public IEnumerable<string> Get()
        {
            return cities.ToList<string>(); // .ToList<string>() method returns cities as a List<string>
        }
    }

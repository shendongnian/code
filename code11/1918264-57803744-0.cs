    public class ValuesController : ApiController
    {
        List<string> cities = new List<string>();
        
        public ValuesController()
        {
            cities.Add("pune");
            cities.Add("Mumbai");
        }
    
        // GET api/values
        public IEnumerable<string> Get()
        {
            return cities ;
        }
    }

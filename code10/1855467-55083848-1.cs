    public class QueryController : ApiController
    {
        [HttpGet]
        public IEnumerable<String> GetNames()
        {
            return new String[] { "John", "Adams" };
        }
    }

    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> GetAll()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpGet]
        public string GetItem(int id)
        {
            return "value";
        }
    }

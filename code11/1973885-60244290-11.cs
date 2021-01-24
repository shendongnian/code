    public class ValuesController : ControllerBase
    {
        // values/getall
        [HttpGet]
        public IEnumerable<string> GetAll()
        {
            return new string[] { "value1", "value2" };
        }
        // values/getitem/1
        [HttpGet]
        public string GetItem(int id)
        {
            return "value";
        }
    }

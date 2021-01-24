    public class ValuesController: ControllerBase
    {
        [HttpGet("Seven")]
        public int Seven(string id)
        {
            return 7;
        }
    }

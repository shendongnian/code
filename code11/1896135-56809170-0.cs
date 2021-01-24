    [Route("api/[controller]/[action]")]
    class HomeController: Controller
    {
        // ... some code here
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
        // ... some code here
    }

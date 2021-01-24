     [Authorize]
    [ApiVersion("1.0")]
    public class HomeController : BaseApiController
    {
        private ILogger _logger;
        public HomeController(ILogger logger) : base(logger)
        {
            this._logger = logger;
        }
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }
        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }
        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }
        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }

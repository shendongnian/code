    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        // GET: api/Tests
        [HttpGet]
        public IEnumerable<Test> GetTest()
        {
            var model = new List<Test>() { 
            new Test(){Id=1,Name="aaa"},
            new Test(){Id=2,Name="bbb"}
            };
            return model;
        }

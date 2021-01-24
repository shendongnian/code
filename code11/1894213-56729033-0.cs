    [Route("api/MyController")]
    public class MyController {
        //GET api/MyController/1000
        [HttpGet("{id:long}")]
        public MyClass Get(long id) {
            Amazon.Lambda.Core.LambdaLogger.Log($"Get(id) is called with {id}");
            return new MyClass { Id = id, Description = "Something" };
        }
    }

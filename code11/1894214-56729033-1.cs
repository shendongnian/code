    [Route("api/MyController")]
    public class MyController {
        //GET api/MyController/1000
        [HttpGet("{tagId:long}")]
        public MyClass Get(long tagId) {
            Amazon.Lambda.Core.LambdaLogger.Log($"Get(tagId) is called with {tagId}");
            return new MyClass { Id = tagId, Description = "Something" };
        }
    }

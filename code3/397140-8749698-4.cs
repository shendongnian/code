    [WebService]
    [ScriptService]
    public class PersonService : WebService
    {
        [ScriptMethod]
        [WebMethod(CacheDuration = CacheHelloWorldTime,
        Description="As simple as it gets - the ubiquitous Hello World.")]
        public string HelloWorld()
        {
            return "Hello World";
        }
    }

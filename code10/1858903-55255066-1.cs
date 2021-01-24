    [TestClass]
        public class HttpTriggerTest : FunctionTestHelper.FunctionTest
        {
            [TestMethod]
            public async Task Request_With_Query()
            {
                var query = new Dictionary<String, StringValues>();
                query.TryAdd("name", "ushio");
                var body = "";
    
                var result = await HttpTrigger.RunAsync(req: HttpRequestSetup(query, body), log: log);
                var resultObject = (OkObjectResult)result;
                Assert.AreEqual("Hello, ushio", resultObject.Value);
                
            }
    
            [TestMethod]
            public async Task Request_Without_Query()
            {
                var query = new Dictionary<String, StringValues>();
                var body = "{\"name\":\"yamada\"}";
    
                var result = await HttpTrigger.RunAsync(HttpRequestSetup(query, body), log);
                var resultObject = (OkObjectResult)result;
                Assert.AreEqual("Hello, yamada", resultObject.Value);
    
            }
    
            [TestMethod]
            public async Task Request_Without_Query_And_Body()
            {
                var query = new Dictionary<String, StringValues>();
                var body = "";
                var result = await HttpTrigger.RunAsync(HttpRequestSetup(query, body), log);
                var resultObject = (BadRequestObjectResult)result;
                Assert.AreEqual("Please pass a name on the query string or in the request body", resultObject.Value);
            }
        }

C#
_client.DefaultRequestHeaders.Authorization = TestsHelper.GetTestUserBearerHeader();
var request = new HttpRequestMessage(new HttpMethod(httpMethod), url);
var response = await _client.SendAsync(request);
var content = await response.Content.ReadAsStringAsync();
Assert.IsNotNull(content);
            
Assert.AreEqual(HttpStatusCode.OK,response.StatusCode);
**Update**
Problem was on both TestServer and in Client
C#
var server = new TestServer(Program.CreateWebHostBuilder(new string[] { }));
client = server.CreateClient();
client.BaseAddress = new Uri(Configurations["Tests:ApiClientUrl"]);

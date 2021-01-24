csharp
[Fact]
public async Task Test1()
{
    using var host = new TestServer(Program.CreateHostBuilder(null));
    var client = host.CreateClient();
    var requestMessage = new HttpRequestMessage(HttpMethod.Get, "/api/controller");
    var result = await client.SendAsync(requestMessage);
    var status = result.StatusCode;
    // TODO: assertions
}
Now when you call your API in a way an exception is thrown, the middleware should be executed and covered.

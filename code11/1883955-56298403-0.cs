Sample.cs
csharp
// .Net Framework, careful here because the sockets will be cached, network changes will break your app
// see http://www.nimaara.com/2016/11/01/beware-of-the-net-httpclient/ for more details
var client = new HttpClient(new MyCustomHandler() { InnerHandler = new HttpClientHandler() });
// .Net Core
client = new HttpClient(new MyCustomHandler() { InnerHandler = new SocketsHttpHandler() { PooledConnectionLifetime = TimeSpan.FromMinutes(1) } });
Parallel.ForEach(Requests, Request =>
{
    var response = client.PutAsync(new Uri($"http://example.com/books/1234/readers/837"), null); //.Result (?)
    // do not dispose of httpclient!
});
MyCustomHandler.cs
csharp
public class MyCustomHandler : DelegatingHandler
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        // the static headers
        request.Headers.Add("Header1", "Value1");
        request.Headers.Add("Header2", "Value2");
        // the unique header
        SignRequest(request);
        return base.SendAsync(request, cancellationToken);
    }
    public void SignRequest(HttpRequestMessage message)
    {
        // usually the pattern of a unique header per request is for an authorization header based on some signature of the request
        // this logic would be here
        // generate the signature
        string signature = new Random().Next(int.MaxValue).ToString();
        message.Headers.Add("Header3", signature);
    }
}

cs
services.AddHttpClient<GithubClient>(c => c.BaseAddress = new System.Uri("https://api.github.com"));
Now we can inject that inside the **typed** GithubClient
cs
public class GithubClient
{
    public GithubClient(HttpClient client)
    {
        // client.BaseAddress is "https://api.github.com"
    }
}
You can't inject the `HttpClient` inside, for example `AnotherClient`, because **it is not typed** to `AnotherClient`
cs
public class AnotherClient
{
    public AnotherClient(HttpClient client)
    {
        // InvalidOperationException, can't resolve HttpClient 
    }
}
You can, however:  
 1. inject the `IHttpClientFactory` and call `CreateClient()`. This client will have `BaseAddress` set to `null`.  
 2. configure `AnotherClient` as a different typed client with, for example, a different `BaseAdress`.
### Update
Based on your comment, you are registering a **Named** client. It is still resolved from the IHttpClientFactory.CreateClient() method, but you need to pass the 'name' of the client
**Registration**  
cs
services.AddHttpClient("githubClient", c => c.BaseAddress = new System.Uri("https://api.github.com"));
**Usage**
cs
// note that we inject IHttpClientFactory
public HomeController(IHttpClientFactory factory)
{
    this.defaultClient = factory.CreateClient(); // BaseAddress: null
    this.namedClient = factory.CreateClient("githubClient"); // BaseAddress: "https://api.github.com"
}

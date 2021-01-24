cs
public class GithubClient
{
    public GithubClient(HttpClient client)
    {
        // client.BaseAddress is "https://api.github.com"
    }
}
you can't inject the HttpClient inside, for example `AnotherClient`
cs
public class AnotherClient
{
    public AnotherClient(HttpClient client)
    {
        // InvalidOperationException, can't resolve HttpClient 
    }
}
You can, however:  
1. inject the HttpClientFactory and call CreateClient(). This client want have `BaseAddress` set to github.com.  
2. configure `AnotherClient` as a different typed client with, for example, different BaseAdress.

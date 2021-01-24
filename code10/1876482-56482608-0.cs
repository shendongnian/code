public class BasicAuthenticationModule : IAuthenticationModule
{
    private const string BASIC_SCHEME = "Basic";
    public bool CanPreAuthenticate => false;
    public string AuthenticationType => BASIC_SCHEME;
    public Authorization Authenticate(string challenge, WebRequest request, ICredentials credentials)
    {
        if (!challenge.StartWith(BASIC_SCHEME)) return null;
        // Some code to get Basic from ICredentials
    }
    public Authorization PreAuthenticate(WebRequest request, ICredentials credentials)
    {
        return null;
    }
}
public class BearerAuthenticationModule : IAuthenticationModule
{
    private const string BEARER_SCHEME = "Bearer";
    public bool CanPreAuthenticate => false;
    public string AuthenticationType => BEARER_SCHEME;
    public Authorization Authenticate(string challenge, WebRequest request, ICredentials credentials)
    {
        if (!challenge.StartWith(BEARER_SCHEME)) return null;
        // Some code to get Bearer from ICredentials
    }
    public Authorization PreAuthenticate(WebRequest request, ICredentials credentials)
    {
        return null;
    }
}
Also pay attention that the challenge is the content of the WWW-Authenticate header send by the server after a first unauthorized response (401) which is not related to the "basic" that you write in the CredentialCache

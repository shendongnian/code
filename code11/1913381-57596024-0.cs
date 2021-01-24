lang-cs
private readonly IVssCredentialsFactory _credentialsFactory;
private const string ApiVersion = "5.1";
private static string BasePath = $"https://dev.azure.com/{Organization}";
private const string Organization = "company";
private const string Project = "project";
public AzureRepository(IVssCredentialsFactory credentialsFactory)
{
    _credentialsFactory = credentialsFactory;
}
public void GetWikiPage()
{
    using (var connection = new VssConnection(new Uri(BasePath), _credentialsFactory.GetCredentials()))
    {
        var wikiClient = connection.GetClient<WikiHttpClient>();
        var wikiId = "KIS.wiki";
        var path = "/News";
        var page = wikiClient.GetPageAsync(Project, wikiId, path, includeContent : true).Result;
        var content = page.Page.Content;
    }
}

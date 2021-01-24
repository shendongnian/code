cs
public delegate GitHubService GitHubServiceFactory(string repositoryName);
cs
public class AnotherService
{
    private GitHubService gitHubService;
    public AnotherService(GitHubServiceFactory gitHubServiceFactory)
    {
        this.gitHubService = gitHubServiceFactory("myRepositoryName");
    }
}
As far as I know this is not possible with the builtin dependency resolver.
   

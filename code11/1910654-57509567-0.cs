c#
class Program
{
    public async static Task Main()
    {
        // client initialization and authentication 
        var client = new GitHubClient(new ProductHeaderValue("<anything>"));
        var user = await client.User.Get("<user>");
        var tokenAuth = new Credentials(APIKeys.GithubPersinalAccessToken);
        client.Credentials = tokenAuth;
        // user input
        Console.WriteLine("Give a title for your issue: ");
        string userIssueTitle = Console.ReadLine().Trim();
        Console.WriteLine("Describe your issue:", Environment.NewLine);
        string userIssue = Console.ReadLine().Trim();
        // input validation
        while (string.IsNullOrEmpty(userIssue) || string.IsNullOrEmpty(userIssueTitle))
        {
            Console.WriteLine("ERROR: Both fields must contain text");
            Console.ReadLine();
            break;
        }
        var newIssue = new NewIssue(userIssueTitle) { Body = userIssue };
        var issue = await client.Issue.Create(<owner>, <repo> newIssue);
        var issueId = issue.Id;
        Console.WriteLine($"SUCCESS: your issue id is {issueId} ");
        Console.ReadLine();
        
    
    }
}
**Note**
You need to store your keys in a separate file and write a class for it so your authentication flow might be different.
**Note 2**
You must replace all <placeholder> text with real values.
 

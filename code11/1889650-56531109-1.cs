    public class QueryGithubRepo : QueryData<GithubRepo> 
    {
        public string User { get; set; }
        public string Organization { get; set; }
    }
    
    public object Get(GetGithubRepos request)
    {
        if (request.User == null && request.Organization == null)
            throw new ArgumentNullException("User");
    
        var url = request.User != null
            ? $"https://api.github.com/users/{request.User}/repos"
            : $"https://api.github.com/orgs/{request.Organization}/repos";
    
        return url.GetJsonFromUrl(requestFilter:req => req.UserAgent = GetType().Name)
            .FromJson<List<GithubRepo>>();
    }

    public class BasicUsageModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;
    
        public IEnumerable<GitHubBranch> Branches { get; private set; }
    
        public bool GetBranchesError { get; private set; }
    
        public BasicUsageModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
    
        public async Task OnGet()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, 
                "https://api.github.com/repos/aspnet/AspNetCore.Docs/branches");
            request.Headers.Add("Accept", "application/vnd.github.v3+json");
            request.Headers.Add("User-Agent", "HttpClientFactory-Sample");
    
            var client = _clientFactory.CreateClient();
    
            var response = await client.SendAsync(request);
    
            if (response.IsSuccessStatusCode)
            {
                Branches = await response.Content
                    .ReadAsAsync<IEnumerable<GitHubBranch>>();
            }
            else
            {
                GetBranchesError = true;
                Branches = Array.Empty<GitHubBranch>();
            }                               
        }
    }

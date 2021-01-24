    public partial class MyRestClient
    {
        public MyRestClient(IOptions<MyRestClientOptions> options, HttpClient httpClient, AutoRefreshingCredentials credentials)
            : base(httpClient, disposeHttpClient: true)
        {
            // to setup url in Startup.ConfigureServices
            BaseUri = options.Value.BaseUri;
            Credentials = credentials ?? throw new ArgumentNullException(nameof(credentials));
        }
    }

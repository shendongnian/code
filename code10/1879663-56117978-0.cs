    public partial class MyAutoRestClientExtended: MyAutoRestClient
    {
        public MyAutoRestClientExtended(HttpClient httpClient, IOptions<SomeOptions> options)
            : base(new EmptyServiceClientCredentials(), httpClient, false)
        {
            var optionsValue = options.Value ?? throw new ArgumentNullException(nameof(options));
            BaseUri = optionsValue .Url;
        }
    }

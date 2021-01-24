    public class ExternalGateway
    {
        private readonly HttpClient _httpClient;
        public ExternalGateway(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<SomeModel> GetSomeExternalResource(Uri uri)
        {
            var response = await _httpClient.GetAsync(uri.AbsoluteUri);
            // TODO: check status
            // do some conversion of the content to your model
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<SomeModel>(content);
        }
    }
    public class SomeModel
    {
        public string SomeProperty { get; set; }
    }

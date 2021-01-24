    public class SomethingServiceApiClient : ISomethingService
    {
        private readonly string _baseUrl;
        public SomethingServiceApiClient(string baseUrl)
        {
            _baseUrl = baseUrl;
        }
        public SomeData GetSomeData(string id)
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest($"something/{id}", Method.POST);
            var response = client.Execute<SomeData>(request);
            return response.Data;
        }
    }

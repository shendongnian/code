    public interface IApi2Service
    {
        Task<Foo> GetFooByIdAsync(int id);
    }
    public class Api2Service : IApi2Service
    {
        private readonly HttpClient _client;
        public Api2Service(HttpClient client)
        {
            _client = client;
        }
        public async Task<Foo> GetFooByIdAsync(int id)
        {
            // use _client to make the API call
        }
    }

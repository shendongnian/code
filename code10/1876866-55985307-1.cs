    public interface IFanApiClientFactory {
      IFanApiClient CreateStarWarsApiClient();
      IFanApiClient CreateStarTrekApiClient();
    }
    public class FanApiClientFactory : IFanApiClientFactory {
      private readonly IHttpClientFactory _httpClientFactory;
    
      public FanApiClientFactory(IHttpClientFactory httpClientFactory) {
        _httpClientFactory = httpClientFactory;
      }
    
      public IFanApiClient CreateStarWarsApiClient() {
        var client = _httpClientFactory.CreateClient(NamedHttpClients.StarWarsApi);
        return new StarWarsApiClient(client);
      }
    
      public IFanApiClient CreateStarTrekApiClient() {
        var client = _httpClientFactory.CreateClient(NamedHttpClients.StarTrekApi);
        return new StarTrekApiClient(client);
      }
    }

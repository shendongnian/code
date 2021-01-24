    public class StarWarsApiClient : IFanApiClient {
      private readonly HttpClient _client;
    
      public StarWarsApiClient(HttpClient client) {
        _client = client;
      }
    
      public async Task<string> GetMostImportantPerson() {
        var response = await _client.GetAsync("people/1");
        return await response.Content.ReadAsStringAsync();
      }
    }
    public class StarTrekApiClient : IFanApiClient {
    
      private readonly HttpClient _client;
    
      public StarTrekApiClient(HttpClient client) {
        _client = client;
      }
    
      public async Task<string> GetMostImportantPerson() {
        var response = await _client.GetAsync("character/CHMA0000126904");
        return await response.Content.ReadAsStringAsync();
      }
    }

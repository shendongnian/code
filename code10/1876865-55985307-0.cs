    public static class NamedHttpClients {
      public const string StarTrekApi = "StarTrekApi";
      public const string StarWarsApi = "StarWarsApi";
    }
    services.AddHttpClient(NamedHttpClients.StarTrekApi, client => {
        client.BaseAddress = new Uri("http://stapi.co/api/v1/rest");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("apiClientTest", "1.0"));
    });
    
    services.AddHttpClient(NamedHttpClients.StarWarsApi, client => {
      client.BaseAddress = new Uri("https://swapi.co/api/");
      client.DefaultRequestHeaders.Accept.Clear();
      client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
      client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("apiClientTest", "1.0"));
    });

          var client = new RestClient(url);
    
          var request = new RestRequest(urlRequest, DataFormat.Json);
    
          var response = client.Get(request);
    
          Console.WriteLine(JsonSerializer.Deserialize<List<TestRestResponseTemplate>>(response.Content)[0].Entity.LegalName.Value);

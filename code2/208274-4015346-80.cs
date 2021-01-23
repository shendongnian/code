         var client = new RestClient("http://example.com");
         // client.Authenticator = new HttpBasicAuthenticator(username, password);
         var request = new RestRequest("resource/{id}");
         request.AddParameter("thing1", "Hello"); 
         request.AddParameter("thing2", "world"); 
         request.AddHeader("header", "value");
         request.AddFile("file", path);
         var response = client.Post(request);
         var content = response.Content; // raw content as string
         var response2 = client.Post<Person>(request);
         var name = response2.Data.Name;
    

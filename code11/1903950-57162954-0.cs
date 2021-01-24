      HttpClient client = new HttpClient();
      client.DefaultRequestHeaders.Accept.Clear();
      client.DefaultRequestHeaders.Accept.Add(new MediaTypeHeaderValue("application/json"));
      byte[] responded;
      HttpResponseMessage response = await client.GetAsync(path);
            
      if (response.IsSuccessStatusCode)
      {
            response.Content.ReadAsByteArrayAsync().Wait();
            responded =  response.Content.ReadAsByteArrayAsync().Result;
            var responseString = Encoding.UTF8.GetString(responded, 0, responded.Length);
            Console.WriteLine("\n " +responseString);
      }

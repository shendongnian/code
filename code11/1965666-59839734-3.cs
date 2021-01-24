     HttpClient client = new HttpClient();
     client.BaseAddress = new Uri("https://webservice.casvpn.com/");
     HttpResponseMessage response = client.GetAsync("serverlist.php").Result; 
     if (response.IsSuccessStatusCode)
     {
          string result = response.Content.ReadAsStringAsync().Result; 
          var obj = System.Text.Json.JsonSerializer.Deserialize<ServerModel>(result);   
     }

     HttpClient client = new HttpClient();
     client.BaseAddress = new Uri("https://webservice.casvpn.com/serverlist.php");
     HttpResponseMessage response = client.GetAsync("").Result; 
     if (response.IsSuccessStatusCode)
     {
          string result = response.Content.ReadAsStringAsync().Result; 
          var obj = System.Text.Json.JsonSerializer.Deserialize<ServerModel>(result);   
     }

    using (var client = new HttpClient())
          {
            var _reqMessage = new HttpRequestMessage();
            _reqMessage.Method = HttpMethod.Get;
            _reqMessage.RequestUri = new Uri("https://en.wikipedia.org/w/api.php?action=query&origin=*&format=json&generator=search&gsrnamespace=0&gsrlimit=100&gsrsearch=S");
    
            var response = client.SendAsync(_reqMessage);
            response.Wait();
    
            var result = response.Result;
            var resultJson = result.Content.ReadAsStringAsync().Result;
    
            var tes = JsonConvert.DeserializeObject<WikiSearchResults>(resultJson);
          }

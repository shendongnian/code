    If you still don't understand or don't know how you would implement it Just copy and paste below code snippet.
    
    
      private static async Task<string> HttpRequest()
            {
    
                object[] body = new object[] 
                {
                    new { CanYCentre = "540" },
                    new { CanYCentre = "960" }
                };
                var requestBody = JsonConvert.SerializeObject(body);
    
                using (var client = new HttpClient())
                using (var request = new HttpRequestMessage())
                {
                    request.Method = HttpMethod.Post;
                    request.RequestUri = new Uri("http://10.10.102.109/api/v1/routing/windows/Window1");
                    request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                    request.Headers.Add("Authorization", "Basic" + "YourAuthKey");
    
                    var response = await client.SendAsync(request);
                    var responseBody = await response.Content.ReadAsStringAsync();
    
                    dynamic result = JsonConvert.DeserializeObject<dynamic>(responseBody);
                    return result;
                }
    			
    		}

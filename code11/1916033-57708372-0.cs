       `public class ServicesClient
        {
          
            private HttpClient httpClient;
            private bool _IsConnection { get { return CheckInternet(); } }
            public bool IsConnection { get { return _IsConnection; } }
    
        
            public ServicesClient()
            {
                httpClient = new HttpClient(new HttpClientHandler());
                //You can change the key as you need and add value 
                httpClient.DefaultRequestHeaders.Add("key", "000000");
            }
    
            //Get Method
            public async Task<T> GetAsync<T>(string URL) where T : class
            {
                if (IsConnection)
                {
                        var result = await httpClient.GetStringAsync(URL);
                        if (!string.IsNullOrEmpty(result))
                            return JsonConvert.DeserializeObject<T>(result);
                        else
                            return null;
                }
                return null;
            }
    
            //Post Method
            public async Task<T> PostAsync<T>(string URL, object param) where T : class
            {
                if (IsConnection)
                {
                    var json = JsonConvert.SerializeObject(param);
                    var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                  
                        var result = await httpClient.PostAsync(URL, httpContent);
                        if (result.IsSuccessStatusCode)
                            
                                return JsonConvert.DeserializeObject<T>(result.Content.ReadAsStringAsync().Result);
                }
                return null;
            }
    
            bool CheckInternet()
            {
                return Connectivity.NetworkAccess == NetworkAccess.Internet;
            }
        }
    }`

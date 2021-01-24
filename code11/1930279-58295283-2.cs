            var client = new HttpClient();
            client.BaseAddress = new Uri("your url");
            int _TimeoutSec = 90;
            client.Timeout = new TimeSpan(0, 0, _TimeoutSec);
            string _ContentType = "application/x-www-form-urlencoded";            
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(_ContentType));
           //if you have any content to send use following keyValuePair
            var kv = new List<KeyValuePair<string, string>>();
            kv.Add(new KeyValuePair<string, string>("key1", "value"));
            kv.Add(new KeyValuePair<string, string>("key2", "value"));
            
            var req = new HttpRequestMessage(System.Net.Http.HttpMethod.Post, "your url") { Content = new FormUrlEncodedContent(kv) };
            var responseAsyn = client.SendAsync(req);
            var response = responseAsyn.GetAwaiter().GetResult();
            TokenModel tokenResponse = new TokenModel();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var responseString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                tokenResponse = JsonConvert.DeserializeObject<TokenModel>(responseString);
            }

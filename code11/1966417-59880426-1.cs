    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Security.Cryptography;
    using System.Text;
 
    var client = new HttpClient();
            public async string Getproduct(string endpoint, string username, string privateKey)
            {
                var queryString = string.Format("?username={0}&version=2", username).ToUpper();
                var hash = GenerateHash(privateKey, queryString);
                client.DefaultRequestHeaders.Accept.Clear();
                //client.BaseAddress = new Uri(baseUri);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
               var url = string.Format("{0}{1}&hash={2}",endpoint, queryString, hash);
                using (HttpResponseMessage response = await client.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        return json;
                    }
                    else
                    {
                        var statusCode = response.StatusCode;
                        //handle code here.
                    }
                }
            }
            public async void PostProduct(string endpoint, string username, string privateKey)
            {
                var queryString = string.Format("?username={0}&version=2", username).ToUpper();
                var hash = GenerateHash(privateKey, queryString);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                var url = string.Format("{0}{1}&hash={2}", endpoint, queryString, hash);
                var dict = new Dictionary<string, string>();
                dict.Add("hotel_id ", "1");
                dict.Add("room_id ", "2");
                var content = new FormUrlEncodedContent(dict);
                using (HttpResponseMessage response = await client.PostAsync(url, content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        var statusCode = response.StatusCode;
                        //handle code here.
                    }
                }
            }
            private string GenerateHash(string privateKey, string queryString)
            {
                var md5 = MD5.Create();
                string salt = queryString;
                byte[] bytes = md5.ComputeHash(Encoding.ASCII.GetBytes(salt + privateKey));
                return BitConverter.ToString(bytes);
            }

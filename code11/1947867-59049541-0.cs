    static async Task<string> PostURI(Uri u, HttpContent c)
        {
            string tokenId = "XXXXX";
            var response = string.Empty;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue("Bearer", tokenId);
                HttpResponseMessage result = await client.PostAsync(u, c);
               // HttpResponseMessage response1 = client.PostAsync(u).Result;
                if (result.IsSuccessStatusCode)
                {                   
                    response = result.StatusCode.ToString();                    
                    
                }
            }          
           // Console.WriteLine(t.Result);
           // Console.ReadLine();
            return response;
        }

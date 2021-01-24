        static async Task<string> PostURI(Uri u, HttpContent c)
        {            
            var response = string.Empty;
            var msg = "";
            using (var client = new HttpClient())
            {
                HttpResponseMessage result = await client.PostAsync(u, c);
                 msg = await result.Content.ReadAsStringAsync();              
                if (result.IsSuccessStatusCode)
                {                   
                    response = result.StatusCode.ToString();                    
                    
                }
            } 
            return response;
        }

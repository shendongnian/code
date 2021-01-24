           [WebMethod]
            public async Task<string> AuthenticateApi()
            {            
                string json = new JavaScriptSerializer().Serialize(new
                {
                    username = ConfigurationManager.AppSettings["username"].ToString(),
                    password = ConfigurationManager.AppSettings["password"].ToString()
                });
        
                string contents;
        
                using (var client = new HttpClient())
                {
                    var response =  await client.PostAsync(ConfigurationManager.AppSettings["Url"].ToString(),  
    new StringContent(json, Encoding.UTF8, "application/json"));
        
                    contents = await response.Content.ReadAsStringAsync();
                }
        
               return contents;
            } 

                [HttpPost]
                [AllowAnonymous]
                public async Task<string>  AuthenticateApi()
                {
                    string json = new JavaScriptSerializer().Serialize(new
                    {
                        username =  ConfigurationManager.AppSettings["username"].ToString(),
                        password =  ConfigurationManager.AppSettings["password"].ToString()
                    });
        
                    var url = ConfigurationManager.AppSettings["Url"].ToString();
        
                    using (var client = new HttpClient())
                    {
                        var response = client.PostAsync(url, new StringContent(json, Encoding.UTF8, "application/json"));
        
                        var contents = await response.Result.Content.ReadAsStringAsync();
        
                        return contents;
                    }
                }

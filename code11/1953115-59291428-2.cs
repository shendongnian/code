            User user = new User();           
            client = GetAuthenticatedHTTPClient();
            client.BaseAddress = new Uri(GraphApi);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            WriteToConsole("Call Graph API :: retrieving AD Info for the employee ::" + email);
            using (client)
            {
                try
                {
                    HttpResponseMessage res = await client.GetAsync("users/" + email);
                    res.EnsureSuccessStatusCode();
                    if (res.IsSuccessStatusCode)
                    {                        
                        user = await res.Content.ReadAsAsync<User>();
                        WriteToConsole("Call Graph API :: Call Success for employee ::" + email);
                        
                    }                    
                }                
                catch (Exception ex)
                {
                    
                    LogError(ex, "Error in Getting AD User info via Graph API");
                    return null;
                }
                return user;
            }
        }

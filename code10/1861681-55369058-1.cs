    class AccessToken
            {
                public string access_token { get; set; }
            }
            // Resource Owner Password Credentials Format
            private async Task<string> GetTokenByROPCFormat()
            {
    
                string tokenUrl = $"https://login.microsoftonline.com/YourTenantId/oauth2/token";
                var req = new HttpRequestMessage(HttpMethod.Post, tokenUrl);
    
                req.Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    ["grant_type"] = "password",
                    ["client_id"] = "ApplicationID",
                    ["client_secret"] = "ApplicationSecret",
                    ["resource"] = "https://graph.microsoft.com",
                    ["username"] = "userEmailwithAccessPrivilege",
                    ["password"] = "YourPassword"
                });
    
                dynamic json;
                dynamic results;
                HttpClient client = new HttpClient();
    
                var res = await client.SendAsync(req);
    
                json = await res.Content.ReadAsStringAsync();
    
                //Token Output
                results = JsonConvert.DeserializeObject<AccessToken>(json);
                Console.WriteLine(results.access_token);
    
    
                //New Block For Accessing Data from Microsoft Graph API
                HttpClient newClient = new HttpClient();
    
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://graph.microsoft.com/v1.0/me");
    
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", results.access_token);
                HttpResponseMessage response = await newClient.SendAsync(request);
    
                string output = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Responsed data Is-\n\n" + output + "");
                return output;
            }

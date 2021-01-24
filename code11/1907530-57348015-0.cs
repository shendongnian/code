    public ActionResult ControLogin(string user, string pass)
            {
                var t = JsonConvert.DeserializeObject<Token>("");
    
                if (user == "" || pass == "")
                {
                    MessageBox.Show("FAILED", "failed");
                    return RedirectToAction("Login");
    
                }
                else
                {
                   
                    var pairs = new List<KeyValuePair<string, string>>
                        {
                            new KeyValuePair<string, string>( "grant_type", "password" ),
                            new KeyValuePair<string, string>( "username", user),
                            new KeyValuePair<string, string> ( "Password", pass )
                        };
                    var content = new FormUrlEncodedContent(pairs);
                    
                    ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
                    using (var client = new HttpClient())
                    {
                        var response = client.PostAsync("https://localhost:44396/" + "Token", content).Result;
                        String token = response.Content.ReadAsStringAsync().Result;
                       
                        if (!string.IsNullOrWhiteSpace(token))
                        {
                            t = JsonConvert.DeserializeObject<Token>(token);
                            
                            client.DefaultRequestHeaders.Clear();
                            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + t.access_token);
                        }
    
                    }
                    if (t.access_token == null)
                    {
                        MessageBox.Show("User Not Found", "ERROR");
                        return RedirectToAction("Login");
    
                    }
                    else
                    {
                        return RedirectToAction("Homeadmin");
                    }
                }
            }

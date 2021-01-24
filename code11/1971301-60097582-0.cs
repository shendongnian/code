                            //try just in case something went wrong whith calling the api
            try
            {
                //Use using so that if the code end the client disposes it self
                using (HttpClient client = new HttpClient())
                {
                    //Setup authentication information
                    string yourusername = "username";
                    string yourpwd = "password";
                    //this is when you expect json to return from the api
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //add the authentication to the request
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", 
                        Convert.ToBase64String(
                            System.Text.ASCIIEncoding.ASCII.GetBytes($"{yourusername}:{yourpwd}")));
                    //api link used to make the call
                    var requestLink = $"apiLink";
                    using (HttpResponseMessage response = client.GetAsync(requestLink).Result)
                    {
                        //Make sure the request was successfull before proceding
                        response.EnsureSuccessStatusCode();
                        //Get response from website and convert to a string
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        //now you have the results
                    }
                }
            }
            //Catch the exception if something went from and show it!
            catch (Exception)
            {
                throw;
            }

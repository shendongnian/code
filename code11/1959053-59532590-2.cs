                [HttpGet]
                public async Task<HttpResponseMessage> GetRequestAsync(HttpRequestMessage Query)
                {                   
                    try
                    {
                        using (HttpClient client = new HttpClient())
                        {                                                          
                            HttpResponseMessage response = await client.GetAsync("http://localhost:8080/document/quicksearch/"+ Query.RequestUri.Query);
        
                            if (response.IsSuccessStatusCode)
                            {
                                Console.Write("Success");
                            }
                            else
                            {
                                Console.Write("Failure");
                            }
        
                            return response;
                        }
                    }
                    catch (Exception e)
                    {        
                        throw e;
                    }
                }
   

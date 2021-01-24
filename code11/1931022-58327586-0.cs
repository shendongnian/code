     public static async Task<UserList>  GetUser()
            {
                //baseUrl
                string baseUrl = "http://pokeapi.co/api/v2/pokemon/";
                try
                {
                    // HttpClient implements a IDisposable interface
                    using (HttpClient client = new HttpClient())
                    {
                        //initiate Get Request 
                        using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                        {
                            //convert response to c# object
                            using (HttpContent content = res.Content)
                            {
                                //convert data content to string using await
                                var data = await content.ReadAsStringAsync();
    
                                //If the data is not null, parse(deserialize) the data to a C# object
                                if (data != null)
                                {
                                    return  JsonConvert.DeserializeObject<UserList>(data);
                                  
                                }
                                else
                                {
                                    return null;
                                }
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    return null;
                }
            }

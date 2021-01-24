             public async Task<List<Thing>> GetThings()
            {
                try
                {
                    var endpoint = $"{Settings.ThingEndpoint}/things";
                    var response = await HttpClient.GetAsync(endpoint);
                    var obj = JsonConvert.DeserializeObject<List<Thing>>(await response.Content.ReadAsStringAsync());
                    if(obj==null)
                    {
                      return await Task.FromException<List<Thing>>(new NullRefernceException());
                    }
                    else
                    {     
                        
                    }
         
                }
                catch (Exception e)
                {
                    Log.Logger.Error(e.ToString());
                    throw;
                
                }
            }

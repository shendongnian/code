    try
            {
                var baseAddress = new Uri("Your base url");
                using (var httpClient = new HttpClient
                {
                    BaseAddress = baseAddress
                })
                {
                    var json =Newtonsoft.Json.JsonConvert.SerializeObject( payload);
                    using (var content = new StringContent( json, System.Text.Encoding.Default, "application/json"))
                    {
                        try
                        {
                            using (var response = await httpClient.PostAsync("end-point url method", content))
                            {
                                 
                                result = await response.Content.ReadAsStringAsync();
                            }
                        }
                        catch(Exception ex)
                        {
                            return ex.Message;
                        }
                       
                    }
                }
                   
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }

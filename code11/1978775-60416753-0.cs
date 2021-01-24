                     ApiRequestModel _requestModel = new ApiRequestModel();
    
                    _requestModel.RequestParam1 = "YourValue";
                    _requestModel.RequestParam2= "YourValue";
                   
    		   
    		        var json = JsonConvert.SerializeObject(_requestModel);
                    var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
    				var reuquestURl = "http://10.10.102.109/api/v1/routing/windows/Window1";
    				var authKey = "YourKey";
    
                    try
                    {
                        HttpResponseMessage responseFromCaseApi = await client.PostAsync(reuquestURl", stringContent);
                        responseFromCaseApi.Headers.Add("Authorization", "Basic" + authKey);
                        if (responseFromCaseApi.IsSuccessStatusCode)
                        {
                            dynamic responseData = responseFromCaseApi.Content.ReadAsStringAsync().Result;
                        }
                        else
                        {
    						dynamic responseData = await responseFromCaseApi.Content.ReadAsStringAsync();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine(ex.Message);
                        return "Whatever you want to return";
                    }

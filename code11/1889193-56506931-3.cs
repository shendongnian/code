    private async Task<HttpResponseMessage> MakeApiCall(string jsonInput,
                                                               string api,
                                                               string apiAction = ApiConstant.CallPost)
    
            {
                // Check / Fetch App Server Address
                var host = "https://www1.oanda.com/rates/api/v2/rates/";
    
                // Create HttpClient
                var client = new HttpClient(new HttpClientHandler {UseDefaultCredentials = true}) { BaseAddress = new Uri(host) };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ApiConstant.JsonHeader));                
    
                // Add String Content
                var stringContent = new StringContent(jsonInput);
    
                // Assign Content Type Header
                stringContent.Headers.ContentType = new MediaTypeHeaderValue(ApiConstant.JsonHeader);
    
                // Make an API call and receive HttpResponseMessage
                HttpResponseMessage responseMessage;
    
                // Process the Relevant Api call action
                switch (apiAction)
                {
                    case ApiConstant.CallPost:
                        responseMessage = await client.PostAsync(api, stringContent);
                        break;
                    case ApiConstant.CallGet:
                        responseMessage = await client.GetAsync(api, HttpCompletionOption.ResponseContentRead);
                        break;
                    case ApiConstant.CallPut:
                        responseMessage = await client.PutAsync(api, stringContent);
                        break;
                    case ApiConstant.CallDelete:
                        responseMessage = await client.DeleteAsync(api);
                        break;
                    default:
                        responseMessage = await client.PostAsync(api, stringContent);
                        break;
                }
    
                return responseMessage;
            }

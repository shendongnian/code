    #r "Newtonsoft.Json"
    using Newtonsoft.Json;
    using System.Net;
    using System.Net.Http.Headers;
    
    public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
    {
        
    
        try
        {
           //Parse query parameter
    
                  log.LogInformation("C# HTTP trigger function processed a request.");
    
                    //Read Request Body
                    var content = await new StreamReader(req.Body).ReadToEndAsync();
    
                    //Extract Request Body and Parse To Class
                    UserAuthentication objUserInfo = JsonConvert.DeserializeObject<UserAuthentication>(content);
    
                   //Message Container
                    dynamic validationMessage;
                         
                  //Validate required param
    
                if (string.IsNullOrEmpty(objUserInfo.UserName.Trim()))
                    {
    					validationMessage = new OkObjectResult("User name is required!");
                        return (IActionResult)validationMessage;
                       
                    }
                if (string.IsNullOrEmpty(objUserInfo.Password.Trim()))
                    {
    					validationMessage = new OkObjectResult("Password is required!");
                        return (IActionResult)validationMessage;
                    }
                
    
                 
                    // Authentication Token Request format
                    string tokenUrl = $"https://login.microsoftonline.com/common/oauth2/token";
                    var tokenRequest = new HttpRequestMessage(HttpMethod.Post, tokenUrl);
    
                    tokenRequest.Content = new FormUrlEncodedContent(new Dictionary<string, string>
                    {
                        ["grant_type"] = "password",
                        ["client_id"] = "YourApplicationId",
                        ["client_secret"] = "YourApplicationPassword",
                        ["resource"] = "https://graph.microsoft.com",
                        ["username"] = "" + objUserInfo.UserName + "",
                        ["password"] = "" + objUserInfo.Password + ""
    
    
                    });
    
                    // Request For Token Endpoint 
    
                    using (var _client = new HttpClient())
                    {
                        var tokenResponse = await _client.SendAsync(tokenRequest);
                        AccessTokenClass objAccessToken = JsonConvert.DeserializeObject<AccessTokenClass>(await tokenResponse.Content.ReadAsStringAsync());
    
                        // When Token Request Null
                        if (objAccessToken.access_token == null)
                        {
    						validationMessage = new OkObjectResult("Invalid Authentication! Please Check Your Credentials And Try Again!");
                            return (IActionResult)validationMessage;
                             
                        }
    					else
    					{
    						  return new OkObjectResult(objAccessToken.access_token);
    					}
    
    
                       
                    }
    
    
               
        }
        catch (Exception ex)
        {
    		    validationMessage = new OkObjectResult("Sorry something went wrong! Please check your given information and try again! {0}" + ex.Message);
                return (IActionResult)validationMessage;
          
        }
    }
    

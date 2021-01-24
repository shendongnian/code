    public static async Task<IActionResult> Run(
                [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
                ILogger log)
            {
                log.LogInformation("C# HTTP trigger function processed a request.");
    
                //Read Request Body
                var content = await new StreamReader(req.Body).ReadToEndAsync();
    
                //Extract Request Body and Parse To Class
                Users objUsers = JsonConvert.DeserializeObject<Users>(content);
    
                //Post Reuqest to another API 
                HttpClient client = new HttpClient();
                var json = JsonConvert.SerializeObject(objUsers);
                //Parsing json to post request content
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
                //Posting data to remote API
                HttpResponseMessage responseFromApi = await client.PostAsync("YourRequstURL", stringContent);
    
                //Variable for next use to bind remote API response
                var remoteApiResponse = "";
                if (responseFromApi.IsSuccessStatusCode)
                {
                   remoteApiResponse = responseFromApi.Content.ReadAsStringAsync().Result; // According to your sample, When you read from server response
                }
    
                //As we have to return IAction Type So converting to IAction Class Using OkObjectResult We Even Can Use OkResult
                var result = new OkObjectResult(remoteApiResponse);
                return (IActionResult)result;
            }

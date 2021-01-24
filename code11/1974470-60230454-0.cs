     [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            try
            {
                //Extract Request Param
                var content = await new StreamReader(req.Body).ReadToEndAsync();
                QnAMakerQuestion objQnAMakerQuestion = JsonConvert.DeserializeObject<QnAMakerQuestion>(content);
                //Global Variable for containing message
                dynamic validationMessage;
                // Validate param
                if (string.IsNullOrEmpty(objQnAMakerQuestion.question))
                {
                    validationMessage = new OkObjectResult("Question is required!");
                    return (IActionResult)validationMessage;
                }
                //Selialize Request Param
                var json = JsonConvert.SerializeObject(objQnAMakerQuestion);
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
                // Call Function 2 
                HttpClient newClient = new HttpClient();
                HttpResponseMessage responseFromAnotherFunction = await newClient.PostAsync("http://localhost:7073/api/Function2FromApp2", stringContent);
                dynamic response = "";
                if (responseFromAnotherFunction.IsSuccessStatusCode)
                {
                    response = responseFromAnotherFunction.Content.ReadAsStringAsync().Result;
                }
                validationMessage = new OkObjectResult(response);
                return (IActionResult)validationMessage;
            }
            catch (Exception ex)
            {
                dynamic validationMessage = new OkObjectResult(string.Format("Something went wrong, please try agian! Reason:{0}", ex.Message));
                return (IActionResult)validationMessage;
            }
        }

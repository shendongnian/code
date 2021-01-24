      [FunctionName("Function2FromApp2")]
            public static async Task<IActionResult> Run(
                [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
                ILogger log)
            {
                log.LogInformation("C# HTTP trigger function processed a request.");
    
                try
                {
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
                    validationMessage = new OkObjectResult(objQnAMakerQuestion);
                    return (IActionResult)validationMessage;
                }
                catch (Exception ex)
                {
    
                    dynamic validationMessage = new OkObjectResult(string.Format("Something went wrong, please try agian! Reason:{0}", ex.Message));
                    return (IActionResult)validationMessage;
                }
            }

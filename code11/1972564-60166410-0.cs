    [FunctionName("Function1")]
            public static void Run(
                [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,ExecutionContext context,
                ILogger log)
            {
                log.LogInformation("C# HTTP trigger function processed a request.");
                MagickNET.SetGhostscriptDirectory(context.FunctionAppDirectory);
                
                using (var img = new MagickImage(context.FunctionAppDirectory + "\\test.jpg"))
                {
                   
                    img.Write(context.FunctionAppDirectory + "\\test.png");
                }
            } 

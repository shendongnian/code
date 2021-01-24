    ```
    c. Update Code
       ```
       [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            [Blob("test/test.json", FileAccess.Read, Connection = "MyStorage")] Stream blob,
            ILogger log,ExecutionContext context)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            
          
            string text=null;
            blob.Seek(0,SeekOrigin.Begin);
            using (StreamReader streamReader = new StreamReader(blob)) {
                while (!streamReader.EndOfStream) {
                  string  textLine = await streamReader.ReadLineAsync();
                    text += textLine;
                }
                dynamic data = JsonConvert.DeserializeObject(text);
                return (ActionResult)new OkObjectResult(data);
            }
                
                
        }

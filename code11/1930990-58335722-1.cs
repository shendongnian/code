      [FunctionName("Function1")]
        public static void Run([BlobTrigger("expenses/{name}.csv", Connection = "AzureWebJobsStorage")]Stream inputBlob, string name,
        [Table("Expenses", Connection = "AzureWebJobsStorage")] IAsyncCollector<Expense> expenseTable,
        ILogger log)
        {
        
         //your other code.
    
         //here, use the HttpClient
         //define the http verb
         var method = new HttpMethod("POST"); 
        
         //add the content to body
         var request = new HttpRequestMessage(method, requestUri)
          {
                Content = new StringContent("your string to post")
          };
          //add content type
          request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/csv"));
          //send
          var httpClient = new HttpClient();
          var result = httpClient.SendAsync(request).Result;
    
        }

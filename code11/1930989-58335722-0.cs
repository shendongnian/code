        [FunctionName("Function1")]
        public static void Run([BlobTrigger("expenses/{name}.csv", Connection = "AzureWebJobsStorage")]Stream inputBlob, string name,
        [Table("Expenses", Connection = "AzureWebJobsStorage")] IAsyncCollector<Expense> expenseTable,
        ILogger log)
        {
    
            //your other code
            using (StreamReader reader = new StreamReader(myBlob))
            {
                string my_content = reader.ReadToEnd();
                
            }
        }

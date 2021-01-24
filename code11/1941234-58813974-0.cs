    public static class Function1
        {
            public class CustomQueueMessage
            {
                public string PersonName { get; set; }
                public string Title { get; set; }
            }
            [FunctionName("Function1")]
            public static void Run(
                [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
                [Queue("myqueue")]CloudQueue myQueueItems,
                ILogger log)
            {
                log.LogInformation("C# HTTP trigger function processed a request.");
                var ms1 = new CustomQueueMessage { PersonName = "You", Title = "None" };
                CloudQueueMessage q1 = new CloudQueueMessage(JsonConvert.SerializeObject(ms1));
                myQueueItems.AddMessageAsync(q1, TimeSpan.FromDays(11),null,null,null);
                CloudQueueMessage q2 = new CloudQueueMessage("test");
                myQueueItems.AddMessageAsync(q2, TimeSpan.MaxValue , null, null,null);
            }
        }

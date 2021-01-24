        #r "Microsoft.Azure.WebJobs.Extensions.SignalRService"
        using Microsoft.Azure.WebJobs.Extensions.SignalRService;
        public static async Task Run(string eventGridEvent, IAsyncCollector<SignalRMessage> signalRMessages, ILogger log)
        {
            log.LogInformation(eventGridEvent);
            await signalRMessages.AddAsync(
                new SignalRMessage
                {
                    Target = "Broadcasting",
                    Arguments = new[] {eventGridEvent }
                });  
        }

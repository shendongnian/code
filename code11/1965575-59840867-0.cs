    using Microsoft.Azure.WebJobs;
    using System.Text;
    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Azure.WebJobs.ServiceBus;
    using Microsoft.ServiceBus.Messaging;
    using Microsoft.Azure.WebJobs.Host;
    
    namespace FunctionApp14
    {
        public static class Function1
        {
            [FunctionName("Function1")]
            public static async Task RunAsync([EventHubTrigger("geoevent", Connection = "eventcon",ConsumerGroup = "geogroup")]EventData[] events, TraceWriter log)
            {
    
                var exceptions = new List<Exception>();
    
                foreach (EventData eventData in events)
                {
                    try
                    {
                        string messageBody = Encoding.UTF8.GetString(eventData.GetBytes());
    
                        // Replace these two lines with your processing logic.
                        log.Info($"C# Event Hub trigger function processed a message: {messageBody}");
                        await Task.Yield();
                    }
                    catch (Exception e)
                    {
                        // We need to keep processing the rest of the batch - capture this exception and continue.
                        // Also, consider capturing details of the message that failed processing so it can be processed again later.
                        exceptions.Add(e);
                    }
                }
    
                // Once processing of the batch is complete, if any messages in the batch failed processing throw an exception so that there is a record of the failure.
    
                if (exceptions.Count > 1)
                    throw new AggregateException(exceptions);
    
                if (exceptions.Count == 1)
                    throw exceptions.Single();
            }
        }
    }

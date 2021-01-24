    using IoTHubTrigger = Microsoft.Azure.WebJobs.EventHubTriggerAttribute;
    using System.Linq;
    //...
    [FunctionName("IoTHubDataFunction")]
    public static void Run2([IoTHubTrigger("messages/events", Connection = "IoTHubTriggerConnection", ConsumerGroup = "funcgroup")]EventData message, ILogger log)
    {
        log.LogInformation($"\nBody:\n\t{Encoding.UTF8.GetString(message.Body.Array)}" +
                           $"\nSystemProperties:\n\t{string.Join("\n\t", message.SystemProperties.Select(i => $"{i.Key}={i.Value}"))}" +
                           $"\nProperties:\n\t{string.Join("\n\t", message.Properties.Select(i => $"{ i.Key}={ i.Value}"))}");
    }

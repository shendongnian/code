csharp
using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
namespace funk_csharp_queue
{
  public class QueueMsg
  {
    public string filename { get; set; }
  }
  public static class ServiceBusTrigger
  {
    [FunctionName("ServiceBusTrigger")]
    public static void Run(
      [ServiceBusTrigger("myqueue", Connection = "ServiceBusConnection")] QueueMsg myQueueItem,
      [Blob("samples-workitems/{filename}", FileAccess.Read)] String myBlob,
      ILogger log)
    {
      log.LogInformation($"C# Service Bus trigger function processed: {JsonConvert.SerializeObject(myQueueItem)}");
      log.LogInformation($"C# Blob input read: {myBlob}");
    }
  }
}
And the message you send in the Service Bus Queue / Topic would be something like this
json
{
  "filename": "11c8f49d-cddf-4b82-a980-e16e8a8e42f8.json"
}
Make sure you set the [Content Type][3] to `application/json`.
  [1]: https://feedback.azure.com/forums/355860-azure-functions
  [2]: https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-expressions-patterns#json-payloads
  [3]: https://docs.microsoft.com/en-us/azure/service-bus-messaging/service-bus-messages-payloads#payload-serialization

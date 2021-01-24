    #r "Newtonsoft.Json"
    using System;
    using System.Threading.Tasks;
    using System.Text;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    public static async Task Run(JObject eventGridEvent, ILogger log)
    {
        log.LogInformation(eventGridEvent.ToString());
  
        string requestUri = $"{eventGridEvent["data"]?["requestUri"]?.Value<string>()}";
        if(!string.IsNullOrEmpty(requestUri))
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", Environment.GetEnvironmentVariable("AzureServiceBus_token"));
                var response = await client.DeleteAsync(requestUri);
                // status & headers
                log.LogInformation(response.ToString());
                // message body
                log.LogInformation(await response.Content.ReadAsStringAsync());
            }
        }
   
        await Task.CompletedTask;
    }
 

    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.Text;
    
    namespace HttpTrigger
    {
        public static class Function1
        {
            public static string GetFileJson(string filepath)
            {
                string json = string.Empty;
                using (FileStream fs = new FileStream(filepath, FileMode.Open, System.IO.FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("utf-8")))
                    {
                        json = sr.ReadToEnd().ToString();
                    }
                }
                return json;
            }
            //Read Json Value
            public static string ReadJson()
            {
                string jsonfile = "host.json";
                string jsonText = GetFileJson(jsonfile);
                JObject jsonObj = JObject.Parse(jsonText);
                string value = ((JObject)jsonObj["extensions"])["serviceBus"]["messageHandlerOptions"]["maxConcurrentCalls"].ToString();
                return value;
            }
            [FunctionName("Function1")]
            public static async Task<IActionResult> Run(
                [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
                ILogger log)
            {
                string value = ReadJson();
    
                log.LogInformation("C# HTTP trigger function processed a request.");
    
                string name = req.Query["name"];
    
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                dynamic data = JsonConvert.DeserializeObject(requestBody);
                name = name ?? data?.name;
    
                return name != null
                    ? (ActionResult)new OkObjectResult($"Hello, {name}")
                    : new BadRequestObjectResult("Please pass a name on the query string or in the request body" + value);
            }
        }
    }

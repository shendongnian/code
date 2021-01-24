    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    
    namespace FunctionAppPostComplexObject
    {
        public static class Function1
        {
            [FunctionName("Function1")]
            public static async Task<IActionResult> Run(
                [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] LabelInformation info,
                ILogger log)
            {
                log.LogInformation("C# HTTP trigger function processed a request.");
    
                LabelInformation labelInformation = info;
    
                //_logger.LogInformation("create the label.");
                string name = "";// req.Query["name"];
    
                //string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
              //  dynamic data = JsonConvert.DeserializeObject(requestBody);
              //  name = name ?? data?.name;
    
                return name != null
                    ? (ActionResult)new OkObjectResult($"Hello, {name}")
                    : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
            }
    
            public class LabelInformation
            {
                public ParcelAddress Receiver { get; set; }
    
                /// <summary>
                /// Invoice number. TODO Should be renamed.
                /// </summary>
                public string ReferenceNumber { get; set; }
    
                /// <summary>
                /// Total weight of the parcel.
                /// </summary>
                public decimal? Weight { get; set; }
            }
    
            public class ParcelAddress
            {
                public string Name1 { get; set; }
                public string AddressLine1 { get; set; }
                public string ZipCode { get; set; }
                public string City { get; set; }
                /// <summary>
                /// Country 2 letter ISO code.
                /// </summary>
                public string CountryCode { get; set; }
            }
        }
    }

#r "Newtonsoft.Json"
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System.Collections.Generic;
public static async Task<IActionResult> Run(HttpRequest req, ILogger log)
{
    log.LogInformation("C# HTTP trigger function processed a request.");
    var test =Environment.GetEnvironmentVariable("test",EnvironmentVariableTarget.Process);
    log.LogInformation(test);
    var values= JsonConvert.DeserializeObject<Dictionary<string, string>>(test);
    var businessUnitMapping = new BusinessUnitMapping();
    businessUnitMapping.Values = values; 
    log.LogInformation(businessUnitMapping.Values["Products"]);
    string name = req.Query["name"];
    string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
    dynamic data = JsonConvert.DeserializeObject(requestBody);
    name = name ?? data?.name;
    return name != null
        ? (ActionResult)new OkObjectResult($"Hello, {name}")
        : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
}
public class BusinessUnitMapping
    {
        public Dictionary<string, string> Values { get; set; }
        public BusinessUnitMapping()
        {
            
        }
    }
[![enter image description here][4]][4]
  [1]: https://docs.microsoft.com/bs-latn-ba/azure/azure-functions/functions-how-to-use-azure-function-app-settings
  [2]: https://i.stack.imgur.com/an1dc.png
  [3]: https://i.stack.imgur.com/CXJFM.png
  [4]: https://i.stack.imgur.com/eSctE.png

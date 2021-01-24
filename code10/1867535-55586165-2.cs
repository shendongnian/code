    #r "Newtonsoft.Json"
    #r "Microsoft.Azure.WebJobs.Extensions.SignalRService"
    
    using System;
    using System.Net;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Primitives;
    using Newtonsoft.Json;
    using Microsoft.Azure.WebJobs.Extensions.SignalRService;
    
    public static IActionResult Run(HttpRequest req, ILogger log, [SignalRConnectionInfo(HubName = "flights")]SignalRConnectionInfo connectionInfo)
    {
        return (ActionResult)new OkObjectResult(connectionInfo);
    }

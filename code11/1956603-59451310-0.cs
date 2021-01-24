    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.Azure.WebJobs.Host;
    using Microsoft.Extensions.Logging;
    
    namespace OrchesterTrigger
    {
        public static class Function1
        {
            [FunctionName("Function1")]
            public static async Task<List<string>> RunOrchestrator(
                [OrchestrationTrigger] DurableOrchestrationContext context)
            {
                var outputs = new List<string>();
                string mytoken = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
                outputs.Add(await context.CallActivityAsync<string>("Function1", mytoken));
                return outputs;
            }
    
            [FunctionName("Function1")]
            public static string SayHello([ActivityTrigger] string mytoken, ILogger log)
            {
                log.LogInformation($"Mytoken is {mytoken}.=======================================");
                return $"Mytoken is {mytoken}!";
            }
    
            [FunctionName("Function1_HttpStart")]
            public static async Task<HttpResponseMessage> HttpStart(
                [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")]HttpRequestMessage req,
                [OrchestrationClient]DurableOrchestrationClient starter,
                ILogger log)
            {
                // Function input comes from the request content.
                string instanceId = await starter.StartNewAsync("Function1", null);
    
                log.LogInformation($"================================Started orchestration with ID = '{instanceId}'.");
    
                return starter.CreateCheckStatusResponse(req, instanceId);
            }
        }
    }

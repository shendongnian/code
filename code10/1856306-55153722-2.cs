    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.Azure.WebJobs.Host;
    using Newtonsoft.Json;
    namespace Forum
    {
        public static class Function1
        {
            [FunctionName("Function1")]
            public static async Task<HttpResponseMessage> Run(
                [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)]
                HttpRequestMessage req,
                TraceWriter log)
            {
                log.Info("C# HTTP trigger function processed a request.");
                //dynamic input =await req.Content.ReadAsAsync<dynamic>();
                ALCBarCodes[] input = await req.Content.ReadAsAsync<ALCBarCodes[]>();
                // Fetching the name from the path parameter in the request URL
                return req.CreateResponse(HttpStatusCode.OK, input);
            }
        }
        public class ALCBarCodes
        {
            public string BarCodeText { get; set; }
            public string BarCodeWidth { get; set; }
            public string BarCodeHeight { get; set; }
            public string BarCodeType { get; set; }
            public string BarCodeFont { get; set; }
        }
    }

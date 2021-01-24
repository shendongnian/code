    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.Azure.WebJobs.Host;
    
    namespace FunctionApp41
    {
        public static class Function1
        {
            [FunctionName("Function1")]
            public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
            {
                log.Info("C# HTTP trigger function processed a request.");
    
                
                var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
                var pdfBytes = htmlToPdf.GeneratePdfFromFile("<file_path_including_sas_token>", "");
    
                var response = req.CreateResponse(HttpStatusCode.OK);
                response.Content = new StreamContent(new MemoryStream(pdfBytes));
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
    
                return response;
            }
        }
    }

c#
var output = await response.Content.ReadAsAsync<byte[]>();
This is intended to work with JSON responses. There are some links erroneously claiming you can make it work with `application/octet-stream` responses by adding the a line to your `WebApiConfig.cs`, such as:
c#
config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/octet-stream"));
I believe that advice is flawed, I've never been able to make it work. If you have that line in your project you should remove it and use the following in your `FileIndex()` method instead:
c#
var output = await response.Content.ReadAsByteArrayAsync();
Here is a complete console application that consumes the `application/pdf` stream from a Web API method and saves it to disk (in the TestClient/bin/Debug folder next to the TestClient.exe file):
c#
using System.Net.Http;
using System.Threading.Tasks;
namespace TestClient
{
    class MainClass
    {
        public static async Task FileIndex()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            var requestUri = "http://localhost:8080/api/files";
            //var requestUri = "https://test-server/api/files";
            //clientHandler.ServerCertificateCustomValidationCallback =
            //    (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient client = new HttpClient(clientHandler);
            HttpResponseMessage response = await client.GetAsync(requestUri);
            if (response.IsSuccessStatusCode)
            {
                var output = await response.Content.ReadAsByteArrayAsync();
                //var path = @"E:\testpdf.pdf";
                var path = @"testpdf.pdf";
                System.IO.File.WriteAllBytes(path, output);
            }
        }
        public static void Main(string[] args)
        {
            FileIndex().Wait();
        }
    }
}
And here is a controller I implemented that demonstrates how to return a PDF file to the client with the proper MIME Type and other metadata information:
c#
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
namespace TestServer.Controllers
{
    public class FilesController : System.Web.Http.ApiController
    {
        [Authorize]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                var fileName = "testpdf.pdf";
                // Where "~/" is the root folder of the Web API server project...
                var localFilePath = HttpContext.Current.Server.MapPath("~/" + fileName);
                var fileInfo = new FileInfo(localFilePath);
                var result = new HttpResponseMessage(HttpStatusCode.OK);
                // WARNING: Don't use IDisposables or using(){} blocks here.
                // IDisposables would need to exist for the duration of the client download.
                result.Content = new ByteArrayContent(File.ReadAllBytes(localFilePath));
                result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                result.Content.Headers.ContentDisposition.FileName = fileName;
                result.Content.Headers.ContentDisposition.CreationDate = fileInfo.CreationTimeUtc;
                result.Content.Headers.ContentDisposition.ModificationDate = fileInfo.LastWriteTimeUtc;
                result.Content.Headers.ContentDisposition.ReadDate = fileInfo.LastAccessTimeUtc;
                result.Content.Headers.ContentLength = fileInfo.Length;
                result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
                return result;
            }
            catch (Exception ex)
            {
                //Use something proper like Serilog to log the exception here...
                Console.WriteLine(ex.ToString(), ex.Message);
            }
            return new HttpResponseMessage(HttpStatusCode.Gone);
        }
    }
}
Hope this helps!

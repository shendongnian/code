 language:C#
using System.Web.Http;
using System.Net;
using System.Net.Http;
using System.IO;
namespace RESTService.Controller
{
  public class TextToSpeechController : ApiController
  {
    [HttpGet, ActionName("Get")]
    [AllowAnonymous]
    public HttpResponseMessage Get(string text)
    {
      HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
      MemoryStream memoryStream = new TTS.TTS().ToWavStream(text);
      HttpContent content = new ByteArrayContent(memoryStream.ToArray());
      content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("audio/wav");
      content.Headers.ContentRange = new System.Net.Http.Headers.ContentRangeHeaderValue(memoryStream.Length);
      content.Headers.ContentLength = memoryStream.Length;
      response.Content = content;
      return response;
    }
  }
}

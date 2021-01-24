 lang-c#
namespace NFEApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        // POST api/upload
        [HttpPost]
        public string Post([FromBody] string xml)
        {
            return xml;
        }
    }
}
An alternative is to have a **IFormCollection** as a parameter in your API method and send a form as **multipart/form-data**.

    [Route("[controller]")]
    [ApiController]
    public class EmailComponentsController : ControllerBase
    {
        [HttpPost]
        public async Task SendEmail(string recipientEmail, string subject, [FromBody] string message, string emailTemplate)
        {
           // your code here...
        }
    }

json
{
    "isBase64Encoded": true|false,
    "statusCode": httpStatusCode,
    "headers": { "headerName": "headerValue", ... },
    "multiValueHeaders": { "headerName": ["headerValue", "headerValue2", ...], ... },
    "body": "..."
}
2. `Controller` actually inherits from `ControllerBase` and adds some stuff to handle views (like the `View` method and `ViewBag`) and some other stuff. Here's an example of  controllers built using each approach.
c#
[Route("[controller]")]
public class AnswerController : Controller
{
    [HttpPost("")]
    public IActionResult Post([FromBody]Answer answer)
    {
        if (ModelState.IsValid) 
        {
            return BadRequest(ModelState);
        }
        
        // yadda yadda yadda
    }
}
c#
[ApiController]
[Route("[controller]")]
public class AnswerController : Controller
{
    [HttpPost("")]
    public IActionResult Post(Answer answer)
    {
        // yadda yadda yadda
    }
}

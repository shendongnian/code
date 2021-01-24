lang-c#
[ApiController]
[Route("api/[controller]")]
public class ThingsController : ControllerBase
{
    // POST api/things/store
    [HttpPost("store")]
    public async Task<IActionResult> Store([FromBody] MultipartFormDataContent content)
    {
        // Do stuff
    }
}

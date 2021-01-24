    public class SampleController : ControllerBase //.Net Core 2.2
    {
     [HttpGet]
     public async Task<IActionResult> Get()
     {
        return Ok("APIs up & running");
     }
     }

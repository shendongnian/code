    [ApiController]
    [Route("api/ux/input/[controller]")]
    public class SelectController : ControllerBase
    {
         [HttpGet("samples")]
         public async Task<JsonResult> Get() => new JsonResult(await sampleService.RetrieveSampleEntity());
    }

    [Route("api/[controller]")]
    [ApiController]
    public class APILopTargetsController : ControllerBase
    {
        [HttpPost("PassThings")]//add the attribute
        public IActionResult PassThings([FromBody]List<Target> things)
        {...}
    }

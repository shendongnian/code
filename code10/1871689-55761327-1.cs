    [Route("api/[controller]")]
    [ApiController]
    public class ActionsController : ControllerBase
    {
        [HttpGet("action")]
        public IActionResult ActionGet()
        {
            return Ok("ActionGet");
        }
        [HttpPost("action")]
        public IActionResult ActionPost()
        {
            return Ok("ActionPost");
        }
    }

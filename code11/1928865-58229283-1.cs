    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase {    
        //GET api/Authentication/VerifyIsLoggedIn
        [HttpGet("[action]")]
        public IActionResult VerifyIsLoggedIn() {
            var result = new { Authenticated = true };
            return Ok(result);
        }
    }

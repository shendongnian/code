    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase {    
        //POST api/Authentication
        [HttpPost]
        public IActionResult VerifyIsLoggedIn() {
            var result = new { Authenticated = true };
            return Ok(result);
        }
    }

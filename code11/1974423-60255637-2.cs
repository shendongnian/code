    [Route("api/[controller]")]
    public class TestController : Controller
    {       
        [Authorize]
        [HttpGet]
        public string Get()
        {
            var claimsIdentity = this.User.Identity as ClaimsIdentity;
            var claim = claimsIdentity.Claims;
            // or
            var data = claimsIdentity.FindFirst("userId").Value;
            return data;
        }
    }

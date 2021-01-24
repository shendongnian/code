    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    
    namespace Test.Controllers
    {
        [ApiController]
        [Route("api/account")]
        public class AccountController : ControllerBase
        {
            private readonly ConnectionStrings connectionStrings;
    
            public AccountController(IOptions<ConnectionStrings> connectionStrings)
            {
                this.connectionStrings = connectionStrings.Value;
            }
    
            [HttpGet, Route("test")]
            public IActionResult Test()
            {
                return Ok("test");
            }
        }
    }

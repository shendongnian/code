    [Authorize]
    [ApiController]
    [Route("api/[controller]/[action]")] // <-- Here it is
    public class JwtController : ControllerBase 
    {
         [AllowAnonymous]
         [HttpPost]
         public async Task<IActionResult> Authenticate([FromBody] LoginViewModel model)
         {
            .......  
         }
    
     
         [HttpGet]
         public static IActionResult GetJwtStatus() 
         {
            ......
         }
    }

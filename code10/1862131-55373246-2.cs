    [BasicAuthentication]
    public class RestrictedController : ApiController
    {
       [AllowAnonymous]
       public IActionResult Authenticate()
       {
          //Your authentication entry point
       }       
    }

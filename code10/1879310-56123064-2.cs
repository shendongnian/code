    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
      [Route("/api/customers")]
      public class ProtectedController : Controller
      {
        public ProtectedController()
        {
        }
    
        public IActionResult Get()
        {
          return Ok(new[] { "One", "Two", "Three" });
        }
      }

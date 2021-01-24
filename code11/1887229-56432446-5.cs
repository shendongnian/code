    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)] 
    [Route("api/[controller]")]
        public class SampleDataController : Controller
        {
        // ..
        }

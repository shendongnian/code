    public class UsersController : ControllerBase
    {
        [HttpGet]
        [Route("v1/users/{id}", Name = nameof(GetUser))]
        public async Task<ActionResult> GetUser([FromRoute(Name = "id")] string userGuid)
        {
           // Changed from [FromQuery(Name = "id")] to [FromRoute(Name = "id")]
           
           // Implementation omitted.
        }
        [HttpGet]
        [Route("v1/users/me", Name = nameof(GetCurrentUser))]
        public async Task<ActionResult> GetCurrentUser()
        {
            // Implementation omitted.
        }
    }

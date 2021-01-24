    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}")]
    public class StuffController : ControllerBase
    {
        [HttpGet("stuff/")]
        [Authorize(Roles = "admin,read-stuff")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IActionResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> Get([BearerTokenFromHeader] string accessToken)
        {
            // use accessToken for token exchange
            // use the new token another to get and return the actual results
        }
    }

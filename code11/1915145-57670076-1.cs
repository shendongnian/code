    [Route("api/v1/[controller]")]
    public class SecurityController : ControllerBase
    {
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Authorize([FromBody] AuthData credentials)
        {
            try
            {
                var tokenString = await ObtainToken(credentials, out long expires);
                return Ok(new SecurityToken() {
                    Token = tokenString,
                    Expires = expires
                });
            }catch(Exception ex)
            {
                return StatusCode(400, "Fail");
            }
        }
    }

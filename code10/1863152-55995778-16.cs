    namespace TestIdentityServer4.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        [Authorize]
        public class CodeAuthorityController : ControllerBase
        {
            [HttpGet()]
            public IActionResult Get()
            {
                try
                {
                    string state = this.Request.Query["state"];
                    if (string.IsNullOrEmpty(state))
                        return StatusCode(500);
                    var code = GenerateCode();
                    SaveCodeAndState(code, state);
                    return Redirect($"http://WebApp2.test.url?code={code}&state={state}");
                }
                catch (Exception e)
                {
                    //Log e
                    return StatusCode(500);
                }
            }
            private string GenerateCode()
            {
                //CryptoRandom.CreateUniqueId(16)
                return "random_base64_value_generated_in_is4_api";
            }
            /// <summary>
            /// Save the code hash and state hash to storage 
            /// </summary>
            private void SaveCodeAndState(string code, string state)
            {
                //Save the code request ({requestId, app1SessionId, hash(code), hash(state), expTime}) to storage with exp time
                //db.SaveCodeRequest(code.Sha256(), state.Sha256())
            }
        }
    }

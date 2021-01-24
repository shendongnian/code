    [AllowAnonymous]
    [Route("[controller]")]
    [ApiController]
    public class VersionDemoController
    {
        [ApiVersion("1.1")]
        [HttpGet("requestStuff")]
        public string RequestStuff()
        {
            return "Stuff using Version 1.1 API";
        }
    }
Update:
Just tried using the attribute on the controller and it seems to work fine, my namespaces are different with the action names the same.  I am using version 3.1.2 of the versioning package though.

    [ApiVersion( "1" )]
    [Route( "api/mystuff" )]
    public class mystuff1: Controller 
    {
        [HttpGet]
        public string Get() => "Mystuff1!";
    }
    [ApiVersion( "2" )]
    [Route( "api/mystuff" )]
    public class mystuff2 : Controller 
    {
        [HttpGet]
        public string Get() => "Mystuff2!";
    }

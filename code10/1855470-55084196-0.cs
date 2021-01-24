    [RoutePrefix("api/v2/company")]
    public class UseV2Controller : ApiController
    {
        [Route("users")]
        public List<user> GetUsers_v2() { return new List<user>(){new user(){ Name ="v2User"} }; }
    }
    [RoutePrefix("api/v3/company")]
    public class UseV3Controller : ApiController
    {
        [Route("users")]
        public List<user> GetUsers_v3() { return new List<user>() { new user() { Name = "v3User" } }; }
    
    }
    public class user
    {
        public string Name { get; set; }
    }

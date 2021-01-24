    public class User
    {
        public string UserId { get; set; }
    }
    public class TestRequest
    {
        [FromBody]
        public User User { get; set; }
        [FromHeader(Name = "Authorization")]
        public string Token { get; set; }
    }

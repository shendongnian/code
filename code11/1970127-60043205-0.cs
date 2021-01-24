    [Route("SomeMethod")]
    [HttpPost]
    public IActionResult SomeMethod([FromBody]Request request)
    {
        return Ok();
    }
    public class Request
    {
        public int Interval { get; set; }
    }

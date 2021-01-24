    [HttpPost]
    public ActionResult<Blub> PostBlub([FromBody] MyRequest request)
    {
        return new Blub(request.Paths);
    }
    public class MyRequest
    {
        public string[] Paths { get; set; }
    }

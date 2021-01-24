    public class MyObject
    {
        public int A { get; set; }
        public int B { get; set; }
    }
    [Route("/TestMe")]
    public IActionResult TestMe([FromQuery] MyObject[] queryData)
    { 
        return Json(queryData);
    }

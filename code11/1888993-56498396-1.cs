    public class MyObject
    {
        [FromQuery]
        public int A { get; set; }
        [FromQuery]
        public int B { get; set; }
    }
    [Route("/TestMe")]
    public IActionResult TestMe(MyObject[] queryData)
    { 
        return Json(queryData);
    }

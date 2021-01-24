    public class MyObject
    {
        [FromQuery]
        public int A { get; set; }
        [FromQuery]
        public int B { get; set; }
    }
    [Route("/TestMe")]
    public IActionResult TestMe(List<MyObject> myList)
    { 
        return Json(myList);
    }

    public IActionResult Test(SomeClass obj)
    {
        return Json(obj);
    }
    public class SomeClass
    {
        public string Foo { get; set; }
        public string Bar { get; set; }
    }

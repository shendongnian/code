    [HttpGet]
    public ActionResult Foo(FooModel model)
    {
       // do stuff
    }
    
    [HttpPost]
    [ActionName("Foo")]
    public ActionResult FooPost(FooModel model)
    {
       // do stuff
    }

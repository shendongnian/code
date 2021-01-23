    [HttpPost]
    public JsonResult GetDataController(
        string param1,
        string param2) 
    {
        var myFoo = new Foo
        {
            Bar1 = "Param1 is: " + param1,
            Bar2 = "Param2 is: " + param2
        };
    
        return Json(myFoo);
    }

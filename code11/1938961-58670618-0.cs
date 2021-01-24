    public IActionResult GetData()
    {
        var service = this.HttpContext.RequestServices.GetService<IMyservice>();
        var property1Value = 1;
        var result = new VMTest()
        {
           property1 = property1Value ,
           dependentyProperty = service.GetData(property1Value )
        };
    
        return View(result);
    }

    public Task WaitAsync()
    {
        return Task.Delay(TimeSpan.FromSeconds(1))
            .ContinueWithThreadPool(_ => 
            {
                var httpContext = System.Web.HttpContext.Current; // null, OK
            });
    }        
    public Task<ActionResult> Index()
    {
        var class1 = new MyClass();
        return class1.WaitAsync().ContinueWithSameContext(_ =>
        {
            var httpContext = System.Web.HttpContext.Current; // not null, WHY???
            return View("Index");
        }
    }

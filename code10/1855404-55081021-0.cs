    public async Task WaitAsync()
    {
        await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(false);
        var httpContext = System.Web.HttpContext.Current; // null, OK
    }
    public async Task<ActionResult> Index()
    {
        var class1 = new MyClass();
        await class1.WaitAsync();
        var httpContext = System.Web.HttpContext.Current; // not null, WHY???
        return View("Index");
    }

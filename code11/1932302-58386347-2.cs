    public IActionResult Index()
    {
        var test = new TestModel() { IsRequired = true };
        return View(test);
    }

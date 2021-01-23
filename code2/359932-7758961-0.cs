    public ActionResult Index()
    {
        var strings = new[] { "String 1", "String 2", "String 3" };
        var model = new MyViewModel
        {
            Text = string.Join(Environment.NewLine, strings)
        };
        return View(model);
    }

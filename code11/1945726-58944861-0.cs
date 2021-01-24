    public IActionResult Index(IData d)
    {
        var getDic = d.getDictionary();
        var Info = getDic["First"];
        return View(Info);
    }

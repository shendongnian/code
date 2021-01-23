    [OutputCache(Duration = 300)]
    [ChildActionOnly]
    public ViewResult MainMenu()
    {
        var model = GetMenuModel();
        return View(model);
    }

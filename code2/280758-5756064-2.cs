    public ActionResult Test()
    {
        var result =
            new Models.IndexViewModel
            {
                value = 1,
                items = new Models.DropDownList().GetDropDownList()
            };
        return View(result);
    }
    [HttpPost]
    public ActionResult Test(Models.Index posatback)
    {
        return View();
    }

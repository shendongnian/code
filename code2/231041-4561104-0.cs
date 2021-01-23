    [HttpPost]
    public ActionResult Index(Model model)
    {
        model.Value += "1";
        ModelState.Clear();
        return View(model);
    }

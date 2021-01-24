    [HttpGet]
    public IActionResult SomeMethod()
    {
        var value = _repo.GetValue();
        TempData["value"] = value; // Store value in temp data
        model.Property = value;
        return View(model);
    }
    [HttpPost]
    public IActionResult SomeMethod([FromForm] SomeModel model)
    {
        if (!ModelState.IsValid)
        {
            model.Property = TempData.Peek("value"); // Retrieve from temp data (may need casting)
            return View(model);
        }
    }

    [HttpPost]
    public IActionResult SomeMethod([FromForm] SomeModel model)
    {
        if (!ModelState.IsValid)
        {
            model.Property = _repo.GetValue();
            return View(model);
        }
    }

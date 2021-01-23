    if (ModelState.IsValid)
    {
        ...
    }
    var parentModel = new ParentViewModel()
    {
        RegisterModel = model;
    };
    return View("Account", parentModel);

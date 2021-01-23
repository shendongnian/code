    if (ModelState.IsValid)
    {
        //go on as normal
    }
    else
    {
        var errors = ModelState.Select(x => x.Value.Errors).ToList();
    }

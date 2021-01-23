    try
    {
        var date = new DateTime(model.Year, model.Month, model.Day);
        ...
    }
    catch(ArgumentOutOfRangeException exception)
    {
        ModelState.AddModelError(...);
    }

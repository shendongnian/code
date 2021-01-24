    var added = ModelHelper.CreateSessionCode(model);
    
    if(added.Error)
    {
        TempData["SessionCodesMessage"] = model.ErrorDescription;
        TempData.Keep("SessionCodesMessage");
        TempData["MessageClass"] = "alert-danger";
        TempData.Keep("MessageClass");
    }
    else
    {
        TempData["SessionCodesMessage"] = "Created session code";
        TempData.Keep("SessionCodesMessage");
        TempData["MessageClass"] = "alert-success";
        TempData.Keep("MessageClass");
    }
    
    return RedirectToAction("Index");

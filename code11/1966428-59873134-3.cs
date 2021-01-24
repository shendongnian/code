    var added = ModelHelper.CreateSessionCode(model);
    
    if(added.Error)
    {
        TempData.Peek["SessionCodesMessage"]; = "Created session code";
        TempData.Peek["MessageClass"]; = "alert-success";
    }
    else
    {
        TempData.Peek["SessionCodesMessage"]; = "Created session code";
        TempData.Peek["MessageClass"]; = "alert-success";
    }
    
    return RedirectToAction("Index");

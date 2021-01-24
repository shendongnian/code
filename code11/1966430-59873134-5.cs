    var added = ModelHelper.CreateSessionCode(model);
    
    if(added.Error)
    {
        //second request, PEEK value so it is not deleted at the end of the request
        TempData["SessionCodesMessage"]; = "Created session code";
        object sessioncodevalue= TempData.Peek("SessionCodesMessage");
        TempData["MessageClass"]; = "alert-success";
        object messageclassvalue= TempData.Peek("MessageClass");
    }
    else
    {
        //second request, PEEK value so it is not deleted at the end of the request
        TempData["SessionCodesMessage"]; = "Created session code";
        object sessioncodevalue= TempData.Peek("SessionCodesMessage");
        TempData["MessageClass"]; = "alert-success";
        object messageclassvalue= TempData.Peek("MessageClass");
    }
    
    return RedirectToAction("Index");

    [HttpPost]
    public async Task<IActionResult> ControllerMethodName (CommentViewModel model)
    {
         await _svc.InsertComment(model); //_svc being your service layer=
         return RedirectToPage("./Index")
         //for return value
        var result = await _svc.InsertComment(model);
       return Json(result);
    }

    public ActionResult ExcelUpload(Models.MyUploadModel myModel)
    {
        if (ModelState.IsValid)
        {
            // all good, save                
        }
        return View(myModel);
    }

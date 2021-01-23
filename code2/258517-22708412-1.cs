    public ActionResult FileUpload(upload mRegister) {
        //Check server side validation using data annotation
        if (ModelState.IsValid) {
            //TO:DO
            var fileName = Path.GetFileName(mRegister.file.FileName);
            var path = Path.Combine(Server.MapPath("~/Content/Upload"), fileName);
            mRegister.file.SaveAs(path);
                
            ViewBag.Message = "File has been uploaded successfully";
            ModelState.Clear();
        }
        return View();
    }

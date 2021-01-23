    [HttpPost]
    public ActionResult Upload(HttpPostedFileBase file) 
    {
        if (file != null && file.ContentLength > 0) 
        {
            if (file.ContentLength > 4096000)
            {
                return RedirectToAction("FileTooBig");
            }
            var fileName = Path.GetFileName(file.FileName);
            var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
            file.SaveAs(path);
        }
        return RedirectToAction("Index");
    }

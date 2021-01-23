    [HttpPost]
    public ActionResult Index(MyViewModel viewModel)
    {
        // if file's content length is zero or no files submitted
        
        if (Request.Files.Count != 1 || Request.Files[0].ContentLength == 0)
        {
            ModelState.AddModelError("uploadError", "File's length is zero, or no files found");
            return View(viewModel);
        }
        // check the file size (max 4 Mb)
        if (Request.Files[0].ContentLength > 1024 * 1024 * 4)
        {
            ModelState.AddModelError("uploadError", "File size can't exceed 4 MB");
            return View(viewModel);
        }
        // check the file size (min 100 bytes)
        if (Request.Files[0].ContentLength < 100)
        {
            ModelState.AddModelError("uploadError", "File size is too small");
            return View(viewModel);
        }
        
        // check file extension
        string extension = Path.GetExtension(Request.Files[0].FileName).ToLower();
        if (extension != ".pdf" && extension != ".doc" && extension != ".docx" && extension != ".rtf" && extension != ".txt")
        {
            ModelState.AddModelError("uploadError", "Supported file extensions: pdf, doc, docx, rtf, txt");
            return View(viewModel);
        }
        // extract only the fielname
        var fileName = Path.GetFileName(file.FileName);
        
        // store the file inside ~/App_Data/uploads folder
        var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
        try
        {
            if (System.IO.File.Exists(path))
                System.IO.File.Delete(path);
            Request.Files[0].SaveAs(path);
        }
        catch (Exception)
        {
            ModelState.AddModelError("uploadError", "Can't save file to disk");
        }
        
        if(ModelState.IsValid)
        {
            // put your logic here
            
            return View("Success");
        }
        
        return View(viewModel);         
    }

    [HttpPost]
    public ActionResult Index(HttpPostedFileBase excelFile)
    {
       /*Somewhere here, I have to save the uploaded file.*/
    
       var fileName = string.Format("{0}\\{1}", Directory.GetCurrentDirectory(), excelFile.FileName);
    
       excelFile.SaveAs(fileName );
    
       //...
    }

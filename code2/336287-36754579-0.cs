    [HttpPost]
    public ActionResult UploadFile(HttpPostedFileBase file)
    {    
        if (file != null && file.ContentLength > 0)
        {
              //var fileName = Path.GetFileName(file.FileName);
              //var path = Path.Combine(directory.ToString(), fileName);
              //file.SaveAs(path);
              var streamfile = new StreamReader(file.InputStream);
              var streamline = string.Empty;
              var counter = 1;
              var createddate = DateTime.Now;
              try
              {
                   while ((streamline = streamfile.ReadLine()) != null)
                   {
                        //do whatever;//

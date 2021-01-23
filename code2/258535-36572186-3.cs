    public ActionResult StoreMyCompany([Bind(Exclude = "Logo")]MyCompanyVM model)
    {
        try
        {        
            byte[] imageData = null;
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase objFiles = Request.Files["Logo"];
                using (var binaryReader = new BinaryReader(objFiles.InputStream))
                {
                    imageData = binaryReader.ReadBytes(objFiles.ContentLength);
                }
            }
           
            if (imageData != null && imageData.Length > 0)
            {
               //Your code
            }
            dbo.SaveChanges();
            return RedirectToAction("MyCompany", "Home");
        }
        catch (Exception ex)
        {
            Utility.LogError(ex);
        }
        return View();
    }

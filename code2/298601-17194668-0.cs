    public ActionResult ChangeProfilePicture()
    {
        var fileUpload = Request.Files[0];
    
        Task.Factory.StartNew(() =>
        {
            Task.Factory.StartNew(() => 
                ResizeAndUpload(fileUpload.InputStream, Size.Original), 
                TaskCreationOptions.AttachedToParent);
    
            Task.Factory.StartNew(() => 
                ResizeAndUpload(fileUpload.InputStream, Size.Profile), 
                TaskCreationOptions.AttachedToParent);
    
            Task.Factory.StartNew(() => 
                ResizeAndUpload(fileUpload.InputStream, Size.Thumb), 
                TaskCreationOptions.AttachedToParent);
        }).Wait();
    
        return Content("Success", "text/plain");
    }

    public ActionResult ChangeProfilePicture()
    {
       var fileUpload = Request.Files[0];
       var threads = new Task[3];
       threads[0] = Task.Factory.StartNew(()=>ResizeAndUpload(fileUpload.InputStream, Size.Original));
       threads[1] = Task.Factory.StartNew(()=>ResizeAndUpload(fileUpload.InputStream, Size.Profile));
       threads[2] = Task.Factory.StartNew(()=>ResizeAndUpload(fileUpload.InputStream, Size.Thumb));
    
       Task.WaitAll(threads, 120000); // wait for 2mins.
    
       return Content("Success", "text/plain");   
    }

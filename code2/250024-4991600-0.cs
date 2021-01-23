    public ActionResult UploadFile(string filename, HttpPostedFileBase thefile)
    {
        if (thefile != null && thefile.ContentLength > 0)
        {
            byte[] buffer = new byte[thefile.ContentLength];
            thefile.InputStream.Read(buffer, 0, buffer.Length);
            _service.SomeMethod(buffer, thefile.ContentType, thefile.FileName);
        }
        ...
    }

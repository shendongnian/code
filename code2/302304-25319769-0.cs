    public ActionResult BuildPreview()
    {
        byte[] b;
        using (MemoryStream ms = new MemoryStream())
        {
            Request.InputStream.CopyTo(ms);
            b = ms.ToArray();
        }
        
        ...
    }

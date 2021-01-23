    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "image/JPEG";
        try
        {
            krystaladbDataContext db = new krystaladbDataContext();
            var binimg = (from i in db.image_tables
                          where i.IMG_ID.Equals(1380)
                          select i.IMG_THUMB).Single();
    
    
            byte[] b = binimg.ToArray();
            context.Response.BinaryWrite(b);
            context.Response.Flush();
        }
        catch (Exception ex)
        {
            context.Response.Write(ex);
        }
    }

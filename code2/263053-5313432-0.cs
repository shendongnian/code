    try
    {
       ...
       ctx.Response.ContentType = "image/pjpeg";
       ctx.Response.BinaryWrite(pict);
    }
    catch
    {
       ctx.Response.ContentType = "image/pjpeg";
       ctx.Response.Write("<img src='/images/defaultevent.jpg'>");
    }

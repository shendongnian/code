    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "image/jpeg";
        using (var image = GenerateBarcode(context.Request.Params["Code"]))
        {
            image.Save(context.Response.OutputStream, ImageFormat.Jpeg);
        }
    }

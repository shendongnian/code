    protected void Page_Load(object sender, EventArgs e)
     {
        Response.ContentType = "image/JPEG";
        System.Drawing.Image objBitmap = GenCode128.Code128Rendering.MakeBarcodeImage(Request.QueryString["mode"] + "", 2,false );
        objBitmap.Save(Response.OutputStream, ImageFormat.Bmp); 
    }

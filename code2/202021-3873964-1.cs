    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ContentType = "image/jpeg";
       
        var data = // .... get the content of the images as bytes. e.g. File.ReadAllBytes("path to image");
    
        Response.OutputStream.Write(data, 0, data.Length);
        Response.OutputStream.Flush(); // Not sure if needed, but doesn't hurt to have it.
        Response.End();
    }

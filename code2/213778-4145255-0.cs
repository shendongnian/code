    protected void Page_Load(object sender, EventArgs e)
    {
        HttpResponse response = HttpContext.Current.Response;
    
        response.Clear();
        response.ContentType = "image/png";
    
        Image outputImage = (Load your image here)
        MemoryStream ms = new MemoryStream();
        outputImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
        ms.WriteTo(response.OutputStream);
        outputImage.Dispose();
        ms.Close();
        
        response.End();
    }

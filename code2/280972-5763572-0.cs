    public void Thumb(string file) 
    {
        System.Drawing.Image image = System.Drawing.Image.FromFile(Server.MapPath(file));
        System.Drawing.Image thumbnailImage = image.GetThumbnailImage(70, 70, new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero);
        System.IO.MemoryStream imageStream = new System.IO.MemoryStream();
        thumbnailImage.Save(imageStream, System.Drawing.Imaging.ImageFormat.Jpeg);
        byte[] imageContent = new Byte[imageStream.Length];
        imageStream.Position = 0;
        imageStream.Read(imageContent, 0, (int)imageStream.Length);
        Response.ContentType = "image/jpeg";
        Response.BinaryWrite(imageContent);
    }

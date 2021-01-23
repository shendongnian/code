    byte[] data;
    
    using(System.IO.MemoryStream stream = new System.IO.MemoryStream())
    {
        image.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
        data = stream.ToArray();
    }

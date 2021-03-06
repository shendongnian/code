    IEnuemrable<byte> binaryImageData = queryExecutor.GetImageData(imageId);
    var memoryStream = new MemoryStream();
    memoryStream.Write(imageByte, 0, binaryImageData.Length);
    System.Drawing.Image image = System.Drawing.Image.FromStream(memoryStream);
    
    // ... create JPEG
    
    context.Response.ContentType = "image/jpeg";
    jpegImage.Save(context.Response.OutputStream, 
                   System.Drawing.Imaging.ImageFormat.Jpeg);

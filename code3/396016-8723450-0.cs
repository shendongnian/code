    Response.ContentType = "image/jpeg";
    using (Bitmap bitmap = barcodeGenerator.Generate(Code))
    {
        bitmap.Save(Response.OutputStream, ImageFormat.Jpeg);
    }

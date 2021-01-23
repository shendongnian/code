    System.IO.Stream stream = new System.IO.MemoryStream();
    Ekran.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
    stream.Position = 0;
    // later:
    Attachment attach = new Attachment(stream, "MyImage.jpg");

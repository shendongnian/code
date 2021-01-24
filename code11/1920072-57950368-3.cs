    var file = new FileInfo(@"c:\temp\input.jpg");
    using (MagickImage image = new MagickImage(file))
    {
        {
            image.Thumbnail(new MagickGeometry(100, 100));
            image.Write(@"C:\temp\thumbnail.jpg");
        }
    }

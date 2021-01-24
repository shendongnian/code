    using (var fullSizeStream = new MemoryStream())
    using (var smallStream = new MemoryStream())
    using (var thumbStream = new MemoryStream())
    using (var reviewThumbStream = new MemoryStream())
    using (var image = Image.Load(inStream))
    {
        // Save original constrained
        var clone = image.Clone(context => context
            .Resize(new ResizeOptions
            {
                Mode = ResizeMode.Max,
                Size = new Size(1280, 1280)
            }));
        clone.Save(fullSizeStream, new JpegEncoder { Quality = 80 });
        //Save three sizes Cropped:
        var jpegEncoder = new JpegEncoder { Quality = 75 };
        clone = image.Clone(context => context
            .Resize(new ResizeOptions
            {
                Mode = ResizeMode.Crop,
                Size = new Size(277, 277)
            }));
        clone.Save(smallStream, jpegEncoder);
        clone = image.Clone(context => context
            .Resize(new ResizeOptions
            {
                Mode = ResizeMode.Crop,
                Size = new Size(100, 100)
            }));
        clone.Save(thumbStream, jpegEncoder);
        clone = image.Clone(context => context
            .Resize(new ResizeOptions
            {
                Mode = ResizeMode.Crop,
                Size = new Size(50, 50)
            }));
        clone.Save(reviewThumbStream, jpegEncoder);
        //...then I just save the streams to blob storage
    }

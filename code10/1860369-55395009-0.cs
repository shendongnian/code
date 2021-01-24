    using (var fullSizeStream = new MemoryStream())
    using (var smallStream = new MemoryStream())
    using (var thumbStream = new MemoryStream())
    using (var reviewThumbStream = new MemoryStream())
    using (var image = Image.Load(inStream))
    {
        // Save original constrained
        image.Mutate(context => context
            .Resize(new ResizeOptions
            {
                Mode = ResizeMode.Max,
                Size = new Size(1280, 1280)
            }));
        image.Save(fullSizeStream, new JpegEncoder { Quality = 80 });
        //Save three sizes Cropped
        image.Mutate(context => context
            .Resize(new ResizeOptions
            {
                Mode = ResizeMode.Crop,
                Size = new Size(277, 277)
            }));
        var jpegEncoder = new JpegEncoder { Quality = 75 };
        image.Save(smallStream, jpegEncoder);
        image.Mutate(context => context
            .Resize(new ResizeOptions
            {
                Mode = ResizeMode.Crop,
                Size = new Size(100, 100)
            }));
        image.Save(thumbStream, jpegEncoder);
        image.Mutate(context => context
            .Resize(new ResizeOptions
            {
                Mode = ResizeMode.Crop,
                Size = new Size(50, 50)
            }));
        image.Save(reviewThumbStream, jpegEncoder);
        //(After this I save the streams to azure blob storage)
    }

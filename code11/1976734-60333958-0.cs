    byte[] photoBytes = File.ReadAllBytes(file);
    // Format is automatically detected though can be changed.
    ISupportedImageFormat format = new JpegFormat { Quality = 70 };
    Size size = new Size(150, 0)
    using (MemoryStream inStream = new MemoryStream(photoBytes))
    {
        using (MemoryStream outStream = new MemoryStream())
        {
            // Initialize the ImageFactory using the overload to preserve EXIF metadata.
            using (ImageFactory imageFactory = new ImageFactory(preserveExifData:true))
            {
                // Load, resize, set the format and quality and save an image.
                imageFactory.Load(inStream)
                            .Resize(size)
                            .Format(format)
                            .Save(outStream);
            }
            // Do something with the stream.
        }
    }

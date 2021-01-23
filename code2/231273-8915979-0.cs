    if (imgAddMessage.Source != null)
    {
        string imageDirectory = "pack://application:,,,/Images";
        BitmapImage src = (BitmapImage)imgAddMessage.Source;
        if (!Directory.Exists(imageDirectory))
            Directory.CreateDirectory(imageDirectory);
        using (FileStream stream = new FileStream(Path.Combine(imageDirectory, imageName), FileMode.Create, FileAccess.ReadWrite))
        {
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(src));
            encoder.Save(stream);
        }
    }

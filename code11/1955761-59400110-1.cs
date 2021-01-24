    foreach (var slide in presentation.Slides)
    {
        var bitmap = new BitmapImage();
        using (var imageStream = slide.ConvertToImage(Syncfusion.Drawing.ImageFormat.Jpeg))
        using (var memoryStream = new MemoryStream())
        {
            imageStream.CopyTo(memoryStream); // force imageStream to be written completely
            memoryStream.Position = 0;
            bitmap.BeginInit();
            bitmap.StreamSource = memoryStream;
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.EndInit();
        }
        VisualAidPPT.Add(bitmap);
    }

    foreach (var slide in presentation.Slides)
    {
        var bitmap = new BitmapImage();
        using (var imageStream = slide.ConvertToImage(Syncfusion.Drawing.ImageFormat.Jpeg))
        {
            imageStream.Position = 0;
            bitmap.BeginInit();
            bitmap.StreamSource = imageStream;
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.EndInit();
        }
        VisualAidPPT.Add(bitmap);
    }

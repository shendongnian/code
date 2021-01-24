    foreach (var slide in presentation.Slides)
    {
        var bitmap = new BitmapImage();
        using (var stream = slide.ConvertToImage(Syncfusion.Drawing.ImageFormat.Jpeg))
        {
            stream.Position = 0;
            bitmap.BeginInit();
            bitmap.StreamSource = stream;
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.EndInit();
        }
        VisualAidPPT.Add(bitmap);
    }

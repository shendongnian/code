    foreach (var slide in presentation.Slides)
    {
        var bitmap = new BitmapImage();
        using (var imageStream = slide.ConvertToImage(Syncfusion.Drawing.ImageFormat.Jpeg))
        using (var image = System.Drawing.Image.FromStream(imageStream))
        using (var memoryStream = new MemoryStream())
        {
            image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            memoryStream.Position = 0;
            bitmap.BeginInit();
            bitmap.StreamSource = memoryStream;
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.EndInit();
        }
        VisualAidPPT.Add(bitmap);
    }

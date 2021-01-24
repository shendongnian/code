    var buffer = Result[0].ProductImage as byte[]; // note Result instead of Resualt
    if (buffer != null)
    {
        using (var stream = new MemoryStream(buffer))
        {
            var bi = new BitmapImage();
            bi.BeginInit();
            bi.CacheOption = BitmapCacheOption.OnLoad;
            bi.StreamSource = stream;
            bi.EndInit();
            ImgProduct.Source = bi;
        }
    }

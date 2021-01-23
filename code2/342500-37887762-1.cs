    BitmapImage image = new BitmapImage();
    image.BeginInit();
    image.CacheOption = BitmapCacheOption.OnLoad;
    image.UriSource = new Uri(ImagePath);
    
    // here
    image.Rotation = Rotation.Rotate270; // or 90, 0, 180
    
    image.EndInit();

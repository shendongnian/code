    BitmapImage Image = new BitmapImage();
    Image.BeginInit();
    Image.CacheOption = BitmapCacheOption.OnLoad;
    Image.UriSource = new Uri(ImagePath);
    
    // here
    Image.Rotation = Rotation.Rotate270; // or 90, 0, 180
    
    Image.EndInit();

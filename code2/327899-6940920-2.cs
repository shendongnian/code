    using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream("image.jpg", System.IO.FileMode.Open, file))
    {
        BitmapImage image = new BitmapImage();
        image.SetSource(stream);
    
        image1.Source = image;
    }

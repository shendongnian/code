    private void loadImages(object sender, RoutedEventArgs e)
    {
        Task.Run(loadImageAsnyc);
    }
    void loadImageAsnyc()
    {
        string[] filePaths = Directory.GetFiles(@"C:\SomeImages");
        foreach (string filePath in filePaths)
        {
            Dispatcher.Invoke(() =>
            {
                Image image = new Image();
                BitmapImage bimage = new BitmapImage();
                bimage.BeginInit();
                bimage.UriSource = new Uri(filePath, UriKind.Absolute);
                bimage.EndInit();
                image.Source = bimage;
                imageList.Add(image);
            });
        }
    }

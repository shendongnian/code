    private async void loadImages(object sender, RoutedEventArgs e)
    {
        await Task.Run(() =>
        {
            var filePaths = Directory.EnumerateFiles(@"C:\SomeImages");
            foreach (string filePath in filePaths)
            {
                var bimage = new BitmapImage();
                bimage.BeginInit();
                bimage.CacheOption = BitmapCacheOption.OnLoad;
                bimage.UriSource = new Uri(filePath, UriKind.Absolute);
                bimage.EndInit();
                bimage.Freeze();
                Dispatcher.Invoke(() => imageList.Add(new Image { Source = bimage }));
            }
        });
    }

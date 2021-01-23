    private void SetImage(Uri loc)
        {
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Render, new Action(() =>
                {
                    
                    BitmapImage  image = new BitmapImage();
                    image.BeginInit();
                    image.UriSource = loc;
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.EndInit();
                    imgDisplay.Source = image;
                }
                ));
    
        }

    Task.Run(() =>
    {
        BitmapImage image = new BitmapImage(new Uri("pack://application:,,,/images/pic.jpeg", UriKind.RelativeOrAbsolute));
        image.Freeze();
        Dispatcher.BeginInvoke(new Action(() => Image = image));
    });

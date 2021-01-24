    private async void BtnUnlockClick(object sender, RoutedEventArgs e)
    {
        var image = (Image)((Button)sender).Content;
        image.Source = new BitmapImage(
            new Uri("pack://application:,,,/Common.Wpf;component/images/locked.png"));
        await Task.Delay(1000);
        Close();
    }

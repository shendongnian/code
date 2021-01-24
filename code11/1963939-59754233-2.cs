    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        var button = (Button)sender;
        button.IsEnabled = false;
        await Task.Run(() =>
        {
            // perform time-consuming action
            Thread.Sleep(5000); // just for test
        });
        button.IsEnabled = true;
    }

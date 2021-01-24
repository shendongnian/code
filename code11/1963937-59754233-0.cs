    private async void btn1_Click(object sender, RoutedEventArgs e)
    {
        var button = (Button)sender;
        button.IsEnabled = false;
        await Task.Run(() =>
        {
            // perform time-consuming action
        }
        button.IsEnabled = true;
    }

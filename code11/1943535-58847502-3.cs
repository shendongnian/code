    private async void BtnInstall_Click(object sender, RoutedEventArgs e)
    {
        lblResponse.Content = "starting...";
        await Task.Run(()=> executeInstall());
        lblResponse.Content = "DONE";
    }
    private void executeInstall()
    {
        Thread.Sleep(1000); //do time consuming operation
        App.Current.Dispatcher.Invoke(() => lblResponse.Content = "Downloading Files...");
        Thread.Sleep(1000); //do time consuming operation
        App.Current.Dispatcher.Invoke(() => lblResponse.Content = "Unzipping Files...");
        Thread.Sleep(1000); //do time consuming operation
        App.Current.Dispatcher.Invoke(() => lblResponse.Content = "Updating Files...");
        Thread.Sleep(1000); //do time consuming operation
    }

    private ContentDialog noWifiDialog;
    private async void DisplayNoWifiDialog()
    {
        noWifiDialog = new ContentDialog()
        {
            Title = "Deserialize Json ",
            Content = new ProgressRing() { Name = "MyProsress", IsActive = true },
            CloseButtonText = "Ok"
        };
    
        await noWifiDialog.ShowAsync();
    }
    
    private Task Deserialize()
    {
        return Task.Run(() =>
        {
            for (int i = 0; i < 1000000000; i++)
            {
             // Simulated time-consuming operation
            }
        });
    }
    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        DisplayNoWifiDialog();
        await Deserialize();
        noWifiDialog.Hide();
    }

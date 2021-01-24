    private async void StartScan_Click(object sender, RoutedEventArgs e)
    {
    	pbStatus.IsIndeterminate = true;
    	StartScan.IsEnabled = false;
    
    	await Task.Delay(5000);
    
    	pbStatus.IsIndeterminate = false;
    	StartScan.IsEnabled = true;
    	StartScan.IsChecked = false;
    }

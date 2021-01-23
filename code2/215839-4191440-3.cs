    private async Task<string> SimLongRunningProcessAsync()
    {
        Thread.Sleep(2000);
        return "Success";
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        button.Content = "Running...";
        var result = await SimLongRunningProcessAsync();
        button.Content = result;
    }

    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        this.IsEnabled = false;
        await Correlate();
        this.IsEnabled = true;
    }
    private Task Correlate()
    {
        return Task.Run(() =>
        {
            var process = new Process();
            process.StartInfo.FileName = "test.exe";
            process.Start();
            process.WaitForExit();
        });
    }

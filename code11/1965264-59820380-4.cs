    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        var vm = (MainWindowViewModel)DataContext;
        vm.IsEnabled = false;
        await Correlate();
        vm.IsEnabled = true;
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

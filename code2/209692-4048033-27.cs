    private async void doCalculation_Click(object sender, RoutedEventArgs e) {
        doCalculation.IsEnabled = false;
        await DoSomeBlockingOperationAsync(GetArgs());
        doCalculation.IsEnabled = true;
    }

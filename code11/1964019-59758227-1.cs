    // class member
    private TimeSpan clickActionDelay = TimeSpan.FromSeconds(3);
    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        firstAction();
        // wait 3 seconds without blocking the UI thread
        await Task.Delay(clickActionDelay);
        secondAction();
    }
    private void firstAction()
    {
        ...
    }
    private void secondAction()
    {
        ...
    }

    private async void clock_Tick(ThreadPoolTimer timer)
    {
        // Do some work.
        // ...
        // Update the UI.
        await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
        () => {
            textBlockClock.Text = clock;
            textBlockWeekDay.Text  weekday;
            textBlockDate.Text = date;
        });
        // Do more work.
        // ....
    }

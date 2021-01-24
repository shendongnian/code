    private void ShowBusyWindow(string message, double top, double left, double height, double width)
    {
        Application.Current.Dispatcher.Invoke(() => {
            BusySplash busyForm = new BusySplash(message, top, left, height, width)
            busyForm.Show();
        });
    }

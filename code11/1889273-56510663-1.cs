    private CancellationTokenSource _displayNotification;
    private Task _displayNotificationTask;
    public StudentDetailsForm()
    {
        _displayNotification = new CancellationTokenSource();
    }
    private void Student_Details_Load(object sender, EventArgs e)
    {
        _displayNotificationTask = DisplayNotification(_displayNotification.Token);
    }
    private async void Student_Details_Closing(object sender, CancelEventArgs e)
    {
        _displayNotification.Cancel();
        await _displayNotificationTask;
    }
    private async Task DisplayNotifications(CancellationToken cancellationToken)
    {
        while (cancellationToken.IsCancellationRequested == false)
        {
            await LoadAndDisplayNotification();
            await Task.Delay(15000, cancellationToken);
        }
    }
    private async Task LoadAndDisplayNotification()
    {
        // Load data and display it.
    }

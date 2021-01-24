    protected override void OnContentRendered(EventArgs e)
    {
        Task.Delay(5000);
        lblText.Content = "Sent for analysis";
        Task.Delay(5000);
        lblText.Content = "Analysis in progress";
        Task.Delay(5000);
        lblText.Content = "Analysis results";
    }

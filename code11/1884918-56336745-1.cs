    private async void ChangeTheColours(Object sender, EventArgs e)
    {
        if(string.IsNullOrWhiteSpace(this.ButtonLabel.Text))
             return;
        try
        {
            ConfigureColors((Button)sender, "C");
            await Task.Delay(200);
            ConfigureColors((Button)sender, State);
        }
        catch (Exception ex)
        {
            Crashes.TrackError(ex,
                new Dictionary<string, string> {
                        {"ChangeTheColours", "Exception"},
                        {"Device Model", DeviceInfo.Model },
                });
        }
    }

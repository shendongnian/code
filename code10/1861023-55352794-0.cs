    CrossMediaManager.Current.PlayingChanged += (sender, e) =>
    {
        Device.BeginInvokeOnMainThread(() =>
        {
            ProgressBar.Progress = e.Progress;
            Duration.Text = "" + e.Duration.TotalSeconds / 1000 + " seconds";            
        });
    };

    void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        if (e.ProgressPercentage = 0)
        {
            tsStatus.Text = "Downloading GPS Data...";
            Invalidate();
            Refresh();
        }
    }

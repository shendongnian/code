    private async Task GetCheckStatus()
    {
        var status = await CheckStatus()
        LblOut.Text = status.Item1.ToString();
        LblStage.Text = status.Item2.ToString();
        LblRetired.Text = status.Item3.ToString();
        LblStop.Text = status.Item4.ToString();
    }

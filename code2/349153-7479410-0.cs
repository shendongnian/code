    protected void UpdateTimer_Tick(object sender, EventArgs e)
    {
        DateStampLabel.Text = DateTime.Now.ToString();
        Image1.ImageUrl += "&CacheBuster=" + DateTime.Now.Ticks.ToString();
        TimedPanel.Update();
    }

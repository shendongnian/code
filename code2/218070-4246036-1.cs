    void HttpHelper_StatusChanged(object sender, EventArgs e)
    {
        var httpHelper = (HttpHelper)sender;
        UpdateStatus(httpHelper.Status);
    }
    void UpdateStatus(HttpHelper.Statuses status)
    {
        if (InvokeRequired)
        {
            Invoke(new Action<HttpHelper.Statuses>(UpdateStatus), status);
        }
        else
        {
            // Your code probably doesn't look like this;
            // it's just an example.
            statusLabel.Text = status.ToString();
        }
    }

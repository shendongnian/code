    public void string Download()
    {
        var manualEvent = new ManualResetEvent(false);
        WebClient client = new WebClient();
        client.DownloadStringCompleted += (sender, e) =>
        {
            if (e.Error != null)
            {
                Dispatcher.BeginInvoke(() => 
                { 
                    ResultLabel.Text = e.Result; 
                });
            } 
            else 
            {
                Dispatcher.BeginInvoke(() => 
                { 
                    ResultLabel.Text = e.Error.ToString(); 
                });
            }
        };
        var url = new Uri(Application.Current.Host.Source.AbsoluteUri + "\\PHP\\GetAdmins.php");
        client.DownloadStringAsync(url);
    }

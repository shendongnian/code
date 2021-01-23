    var wc = new WebClient();
    wc.DownloadStringCompleted += (sender, e) =>
    {
        using (sender as IDisposable)
        {
            myTextBox.Text = e.Result;
        }
    };
    wc.DownloadStringAsync(new Uri("http://stackoverflow.com"));

    using (WebClient wc = new WebClient())
    {
        wc.DownloadStringAsync(new Uri("http://stackoverflow.com"), null);
        wc.DownloadStringCompleted += (s, e) =>
        {
            string outputMessage = e.Result;
            Dispatcher.BeginInvoke(() =>
            {
                    resultTextBlock.Text = outputMessage;
            });
        };
    }

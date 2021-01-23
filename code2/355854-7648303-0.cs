    using (WebClient wc = new WebClient())
    {
        wc.DownloadStringCompleted += (s, e) =>
            {
                string fileContent = (string)e.Result;
            };
        wc.DownloadStringAsync(new Uri(fileUrl));
    }

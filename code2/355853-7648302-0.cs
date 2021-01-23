    public void GetFile(string fileUrl)
    {
        using (WebClient wc = new WebClient())
        {
            wc.DownloadStringCompleted += 
                (s, e) => {
                    // Now you have access to `e.Result` here.
                };
            wc.DownloadStringAsync(new Uri(fileUrl));
        }
    }

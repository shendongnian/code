    public static async Task<string> DownloadStringAsync(Uri uri, int timeOut = 60000)
    {
        string output = null;
        bool cancelledOrError = false;
        using (var client = new WebClient())
        {
            client.DownloadStringCompleted += (sender, e) =>
            {
                if (e.Error != null || e.Cancelled)
                {
                    cancelledOrError = true;
                }
                else
                {
                    output = e.Result;
                }
            };
            client.DownloadStringAsync(uri);
            var n = DateTime.Now;
            while (output == null && !cancelledOrError && DateTime.Now.Subtract(n).TotalMilliseconds < timeOut)
            {
                await Task.Delay(100); // wait for respsonse
            }
        }
        return output;
    }

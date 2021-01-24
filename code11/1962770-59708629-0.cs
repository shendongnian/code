    public static class WebClientExtensions
    {
        public static async Task<string> DownloadStringTaskAsync(
            this WebClient webClient,
            string address,
            IProgress<int> progress)
        {
            try
            {
                webClient.DownloadProgressChanged += downloadProgressChanged;
                return await webClient.DownloadStringTaskAsync(address);
            }
            finally
            {
                webClient.DownloadProgressChanged -= downloadProgressChanged;
            }
    
            void downloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
            {
                progress.Report(e.ProgressPercentage);
            }
        }
    }

        private int _percentageDownloaded;
        private void FileUploadProgressChanged(object sender, UploadProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage % 10 == 0 && e.ProgressPercentage > _percentageDownloaded)
            {
                
                _percentageDownloaded = e.ProgressPercentage;
                //Any callback instead of printline
                Console.WriteLine("Send: {0} Received: {1}", e.BytesSent, e.BytesReceived);
            }
        }

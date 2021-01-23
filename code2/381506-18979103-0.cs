    private void downloadMyWorkProgress(object sender, DownloadProgressChangedEventArgs e)
    {
        double bytesIn = double.Parse(e.BytesReceived.ToString());
        double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
        double percentage = bytesIn / totalBytes * 100;
        progressBar1.Value = int.Parse(Math.Truncate(percentage).ToString());
    }

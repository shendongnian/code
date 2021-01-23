    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        var ftpWebRequest = (FtpWebRequest)WebRequest.Create("ftp://example.com");
        ftpWebRequest.Method = WebRequestMethods.Ftp.UploadFile;
        using (var inputStream = File.OpenRead(fileName))
        using (var outputStream = ftpWebRequest.GetRequestStream())
        {
            var buffer = new byte[1024 * 1024];
            int totalReadBytesCount = 0;
            int readBytesCount;
            while ((readBytesCount = inputStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                outputStream.Write(buffer, 0, readBytesCount);
                totalReadBytesCount += readBytesCount;
                var progress = totalReadBytesCount * 100.0 / inputStream.Length;
                backgroundWorker1.ReportProgress((int)progress);
            }
        }
    }
    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
        progressBar.Value = e.ProgressPercentage;
    }

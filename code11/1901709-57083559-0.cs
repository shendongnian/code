c#
private void DownloadPatch(Patch patch){
    //using background worker now!
    downloadBackgroundWorker = new BackgroundWorker();
    downloadBackgroundWorker.DoWork += (sender, e) => DownloadFile_DoWork(sender, e, patch);
    downloadBackgroundWorker.ProgressChanged += DownloadFile_ProgressChanged;
    downloadBackgroundWorker.RunWorkerCompleted += DownloadFile_RunWorkerCompleted;
    downloadBackgroundWorker.WorkerReportsProgress = true;
    downloadBackgroundWorker.RunWorkerAsync();
}
private void DownloadFile_DoWork(object sender, DoWorkEventArgs e, Patch patch)
{
    string startupPath = Application.StartupPath;
    string downloadPath = Path.Combine(Application.StartupPath, patch.path);
    string path = ("http://www.dagovaxgames.com/api/downloads/" + patch.path);
    long iFileSize = 0;
    int iBufferSize = 1024;
    iBufferSize *= 1000;
    long iExistLen = 0;
    System.IO.FileStream saveFileStream;
    // Check if file exists. If true, then check amount of bytes
    if (System.IO.File.Exists(downloadPath))
    {
        System.IO.FileInfo fINfo =
           new System.IO.FileInfo(downloadPath);
        iExistLen = fINfo.Length;
    }
    if (iExistLen > 0)
        saveFileStream = new System.IO.FileStream(downloadPath,
          System.IO.FileMode.Append, System.IO.FileAccess.Write,
          System.IO.FileShare.ReadWrite);
    else
        saveFileStream = new System.IO.FileStream(downloadPath,
          System.IO.FileMode.Create, System.IO.FileAccess.Write,
          System.IO.FileShare.ReadWrite);
    System.Net.HttpWebRequest hwRq;
    System.Net.HttpWebResponse hwRes;
    hwRq = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(path);
    hwRq.AddRange((int)iExistLen);
    System.IO.Stream smRespStream;
    hwRes = (System.Net.HttpWebResponse)hwRq.GetResponse();
    smRespStream = hwRes.GetResponseStream();
    iFileSize = hwRes.ContentLength;
    //using webclient to receive file size
    WebClient webClient = new WebClient();
    webClient.OpenRead(path);
    long totalSizeBytes = Convert.ToInt64(webClient.ResponseHeaders["Content-Length"]);
    int iByteSize;
    byte[] downBuffer = new byte[iBufferSize];
    while ((iByteSize = smRespStream.Read(downBuffer, 0, downBuffer.Length)) > 0)
    {
        if (stopDownloadWorker == true)
        {
            autoDownloadReset.WaitOne();
        }
        saveFileStream.Write(downBuffer, 0, iByteSize);
        long downloadedBytes = new System.IO.FileInfo(downloadPath).Length;
        // Report progress, hint: sender is your worker
        int percentage = Convert.ToInt32(100.0 / totalSizeBytes * downloadedBytes);
        (sender as BackgroundWorker).ReportProgress(percentage, null);
    }
}
As you can see, I report the progress, so that I have a working progress bar as well.
c#
private void DownloadFile_ProgressChanged(object sender, ProgressChangedEventArgs e)
{
    statusTextLabel.Text = "Downloading updates for version " + currentDownloadingPatch + " (" + e.ProgressPercentage + "%)";
    progressBar.Value = e.ProgressPercentage;
}

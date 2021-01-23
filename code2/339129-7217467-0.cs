    WebClient Client = new WebClient();
    Client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
... 
      void ProgressChanged(object sender, DownloadProgressChangedEventArgs e) {
             
                double bytesIn = double.Parse(e.BytesReceived.ToString());
                double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                double percentage = bytesIn / totalBytes * 100;
                int percente = int.Parse(Math.Truncate(percentage).ToString());
                progressBar.Value = percente;
            }

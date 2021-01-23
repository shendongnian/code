    private readonly object streamLocker = new object();
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        lock(streamLocker)
        {
            NetworkStream serverStream = clientSocket.GetStream();
            XmlReader r = XmlReader.Create(serverStream);
            while (r.Read())
            {
              //  output something using backgroundWorker1.ReportProgress object
            }
        }
    }

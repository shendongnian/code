    class Downloader
    {
        private const int chunkSize = 1024;
        private bool doDownload = true;
    
        private string url;
        private string filename;
    
        private Thread downloadThread;
    
        public long FileSize
        {
            get;
            private set;
        }
        public long Progress
        {
            get;
            private set;
        }
    
        public Downloader(string Url, string Filename)
        {
            this.url = Url;
            this.filename = Filename;
        }
    
        public void StartDownload()
        {
            Progress = 0;
            FileSize = 0;
            commenceDownload();
        }
    
        public void PauseDownload()
        {
            doDownload = false;
            downloadThread.Join();
        }
    
        public void ResumeDownload()
        {
            doDownload = true;
            commenceDownload();
        }
    
        private void commenceDownload()
        {
            downloadThread = new Thread(downloadWorker);
            downloadThread.Start();
        }
    
        public void downloadWorker()
        {
            // Creates an HttpWebRequest with the specified URL. 
            HttpWebRequest myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
    
            FileMode filemode;
            // For download resume
            if (Progress == 0)
            {
                filemode = FileMode.CreateNew;
            }
            else
            {
                filemode = FileMode.Append;
                myHttpWebRequest.AddRange(Progress);
            }
    
            // Set up a filestream to write the file
            // Sends the HttpWebRequest and waits for the response.			
            using (FileStream fs = new FileStream(filename, filemode))
            using (HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse())
            {
                // Gets the stream associated with the response.
                Stream receiveStream = myHttpWebResponse.GetResponseStream();
    
                FileSize = myHttpWebResponse.ContentLength;
    
                byte[] read = new byte[chunkSize];
                int count;
    
    
                while ((count = receiveStream.Read(read, 0, chunkSize)) > 0 && doDownload)
                {
                    fs.Write(read, 0, count);
                    count = receiveStream.Read(read, 0, chunkSize);
    
                    Progress += count;
                }
            }
        }
    }

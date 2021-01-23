    class FileUploader : IDisposable
    {
        private readonly WebClient _client;
        private readonly Uri _address;
        private readonly string _filePath;
        private bool _uploadCompleted;
        private bool _uploadStarted;
        private bool _succes;
        public FileUploader(string address, string filePath)
        {
            _client = new WebClient();
            _address = new Uri(address);
            _filePath = filePath;
            _client.UploadProgressChanged += FileUploadProgressChanged;
            _client.UploadFileCompleted += FileUploadFileCompleted;
        }
        private void FileUploadFileCompleted(object sender, UploadFileCompletedEventArgs e)
        {
            _succes = (e.Cancelled || e.Error == null) ? false : true;
            _uploadCompleted = true;
        }
        private void FileUploadProgressChanged(object sender, UploadProgressChangedEventArgs e)
        {
            if(e.ProgressPercentage % 10 == 0)
            {
                //This writes the pecentage data uploaded and downloaded
                Console.WriteLine("Send: {0}, Received: {1}", e.BytesSent, e.BytesReceived);
                //You can have a delegate or a call back to update your UI about the percentage uploaded
                //If you don't have the condition (i.e e.ProgressPercentage % 10 == 0 )for the pecentage of the process 
                //the callback will slow you upload process down
            }
        }
        public bool Upload()
        {
            if (!_uploadStarted)
            {
                _uploadStarted = true;
                _client.UploadFileAsync(_address, _filePath);
            }
            while (!_uploadCompleted)
            {
                Thread.Sleep(1000);
            }
            return _succes;
        }
        public void Dispose()
        {
            _client.Dispose();
        }
    }

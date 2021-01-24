    struct FtpSetting
    {
        public string Server { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FileName { get; set; }
        public string FullName { get; set; }
        public string[] Files { get; set; }
    }
    .
    .
    .
    _inputParameter.Files = files;
    backgroundWorker.RunWorkerAsync(_inputParameter);

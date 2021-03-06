    class FileResult
    {
        public FileResult(SftpResult resultCode, IEnumerable<string> files)
        {
             ResultCode = resultCode;
             FileList = new List<string>(files);
        }
        public SftpResult ResultCode { get; private set; }
        public List<string> FileList { get; private set; }
    }

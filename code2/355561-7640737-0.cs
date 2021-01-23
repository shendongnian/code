    class FileInfoView
    {
        public FileInfo Info { get; private set; }
        
        public FileInfoView(FileInfo info)
        {
            Info = info;
        }
        public override string ToString()
        {
            // return whatever you want here
        }
    }

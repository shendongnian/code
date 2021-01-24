    class FileUpload
    {
        public int InternalId { get; private set; }
        public FileUploadId Id 
        {
            get { return new FileUploadId(InternalId); }
            set { InternalId = value.Value; }
        }
    }

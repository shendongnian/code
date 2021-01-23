        public Uri ArtifactUri { get; }
        public Uri ArtifactUriLatestItemVersion { get; }
        public int ChangesetId { get; }
        public DateTime CheckinDate { get; }
        public static IComparer Comparer { get; }
        public long ContentLength { get; }
        public int DeletionId { get; }
        public int Encoding { get; }
        public byte[] HashValue { get; }
        public bool IsBranch { get; }
        public bool IsContentDestroyed { get; }
        public int ItemId { get; }
        public Stream DownloadFile();
        public void DownloadFile(string localFileName);

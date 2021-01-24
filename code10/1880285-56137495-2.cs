    sealed class ReadFileResult : IDisposable
        // (use a `sealed` class with a non-virtual Dispose method for simpler compliance with IDisposable)
    {
        private readonly FileStream zipFileStream;
        public Stream InnerFileStream { get; }
        
        internal ReadFileResult( FileStream zipFileStream, Stream innerFileStream )
        {
            this.zipeFileStream = zipFileStream;
            this.InnerFileStream = innerFileStream;
        }
        public void Dispose()
        {
            this.InnerFileStream.Dispose();
            this.zipFileStream.Dispose();
        }
    }
    public static ReadFileResult ReadFile(Models.Document document, string path, string password, string fileName)
    {
        // ...
        return new ReadFileResult( zipFileStream: fsIn, innerFileStream: zipStream );
    }

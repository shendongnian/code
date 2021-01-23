    private class StreamWrapper : Stream
    {
        private readonly FastBinaryReader reader;
        private readonly Stream baseStream;
        public StreamWrapper(FastBinaryReader reader, Stream baseStream)
        {
            this.reader = reader;
            this.baseStream = baseStream;
        }
        public override long Length
        {
            get { return reader.Length; }
        }
        public override long Position
        {
            get { return reader.Position; }
            set { reader.Position = value; }
        }
        // Override all other Stream virtuals as well
    }

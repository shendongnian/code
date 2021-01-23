    public class AmazonS3Stream : Stream
    {
        private Stream stream;
        private GetObjectResponse Response;
        public AmazonS3Stream(GetObjectResponse response)
        {
            this.stream = response.ResponseStream;
            this.Response = response;
        }
        // The whole purpose of this class
        protected override void Dispose(bool disposing)
        {
            // base.Dispose(disposing); // Do we really need this line? Probably not since I tested it and I can see that the "this" stream is disposed when Response.Dispose is called by itself
            Response.Dispose();
        }
        public override long Position
        {
            get { return stream.Position; }
            set { stream.Position = Position; }
        }
        public override long Length
        {
            get { return stream.Length; }
        }
        public override bool CanRead
        {
            get { return stream.CanRead; }
        }
        public override bool CanSeek
        {
            get { return stream.CanSeek; }
        }
        public override bool CanWrite
        {
            get { return stream.CanWrite; }
        }
        public override void Flush()
        {
            stream.Flush();
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            stream.Write(buffer, offset, count);
        }
        public override void SetLength(long value)
        {
            stream.SetLength(value);
        }
        public override long Seek(long offset, SeekOrigin origin)
        {
            return stream.Seek(offset, origin);
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
            return stream.Read(buffer, offset, count);
        }
    }

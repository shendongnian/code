    public class CdnFilter : MemoryStream
    {
        private readonly Stream _outputStream;
        public CdnFilter(Stream outputStream)
        {
            _outputStream = outputStream;
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            var contentInBuffer = Encoding.UTF8.GetString(buffer);
            // TODO: do the replacing here
            contentInBuffer = Regex.Replace(...);
            _outputStream.Write(Encoding.UTF8.GetBytes(contentInBuffer), offset, Encoding.UTF8.GetByteCount(contentInBuffer));
        }
    }

    WebRequest req = HttpWebRequest.Create(link);
    WebResponse res = req.GetResponse();
    var stream = res.GetResponseStream();
    var streamWithLenght = new WebStreamWithLenght(stream, res.ContentLength);
    
        public class WebStreamWithLenght : Stream
        {
            long _Lenght;
            Stream _Stream;
            long _Position;
        
            public WebStreamWithLenght(Stream stream, long lenght)
            {
                _Stream = stream;
                _Lenght = lenght;
            }
        
            public override bool CanRead
            {
                get { return _Stream.CanRead; }
            }
        
            public override bool CanSeek
            {
                get { return true; }
            }
        
            public override bool CanWrite
            {
                get { return _Stream.CanWrite; }
            }
        
            public override void Flush()
            {
                _Stream.Flush();
            }
        
            public override long Length
            {
                get { return _Lenght; }
            }
        
            public override long Position { get; set; }
        
            public override int Read(byte[] buffer, int offset, int count)
            {
                var result = _Stream.Read(buffer, offset, count);
                Position += count;
                return result;
            }
        
            public override long Seek(long offset, SeekOrigin origin)
            {
                throw new NotImplementedException();
            }
        
            public override void SetLength(long value)
            {
                _Lenght = value;
            }
        
            public override void Write(byte[] buffer, int offset, int count)
            {
                Write(buffer, offset, count);
            }
        }

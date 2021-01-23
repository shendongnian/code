    public class ObservableStream : Stream
    {
      private readonly Stream _baseStream;
      private Int64 _streamLength;
    
      public event EventHandler<ObservableStreamEventArgs> BytesRead;
      public event EventHandler<ObservableStreamEventArgs> BytesWritten;
    
      public ObservableStream(Stream stream)
      {
        Verify.NotNull(stream);
    
        _baseStream = stream;
        _streamLength = _baseStream.Length;
      }
    
      public ObservableStream(Stream stream, Int64 length)
      {
        Verify.NotNull(stream);
    
        _baseStream = stream;
        _streamLength = length;
      }
    
      public override bool CanRead      
      {        
        get { return _baseStream.CanRead; }
      }
    
      public override bool CanSeek
      {
        get { return _baseStream.CanSeek; }
      }
    
      public override bool CanWrite
      {
        get { return _baseStream.CanWrite; }
      }
    
      public override void Flush()
      {
        _baseStream.Flush();
      }
    
      public override Int64 Length
      {
          get { return _streamLength; }
        }
    
        public override Int64 Position
        {
          get { return _baseStream.Position; }
          set { _baseStream.Position = value; }
        }
    
        public override Int32 Read(Byte[] buffer, Int32 offset, Int32 count)
        {
          Int32 bytesRead = _baseStream.Read(buffer, offset, count);
    
          var listeners = BytesRead;
          if (listeners != null)
            listeners.Invoke(this, new ObservableStreamEventArgs(bytesRead, Position, Length));
    
          return bytesRead;
        }
    
        public override Int64 Seek(Int64 offset, SeekOrigin origin)
        {
          return _baseStream.Seek(offset, origin);
        }
    
        public override void SetLength(Int64 value)
        {
          _streamLength = value;
        }
    
        public override void Write(Byte[] buffer, Int32 offset, Int32 count)
        {
          _baseStream.Write(buffer, offset, count);
    
          var listeners = BytesWritten;
          if (listeners != null)
            listeners.Invoke(this, new ObservableStreamEventArgs(count, Position, Length));
        }
    
        public override void Close()
        {
          _baseStream.Close();
    
          base.Close();
        }
    
        protected override void Dispose(bool disposing)
        {
          if (disposing)
            _baseStream.Dispose();
    
          base.Dispose(disposing);
        }
      }

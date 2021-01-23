      public class BlockingStream : Stream
      {
        private BlockingCollection<byte> _data;    
        private CancellationTokenSource _cts = new CancellationTokenSource();
        private int _readTimeout = -1;
        private int _writeTimeout = -1;    
        public BlockingStream(int maxBytes)
        {
          _data = new BlockingCollection<byte>(maxBytes);      
        }
        public override int ReadTimeout
        {
          get
          {
            return _readTimeout;
          }
          set
          {
            _readTimeout = value;
          }
        }
        public override int WriteTimeout
        {
          get
          {
            return _writeTimeout;
          }
          set
          {
            _writeTimeout = value;
          }
        }
        public override bool CanTimeout
        {
          get
          {
            return true;
          }
        }
        public override bool CanRead
        {
          get { return true; }
        }
        public override bool CanSeek
        {
          get { return false; }
        }
        public override bool CanWrite
        {
          get { return true; }
        }
        public override void Flush()
        {
          return;
        }
        public override long Length
        {
          get { throw new NotImplementedException(); }
        }
        public override long Position
        {
          get
          {
            throw new NotImplementedException();
          }
          set
          {
            throw new NotImplementedException();
          }
        }
        public override long Seek(long offset, SeekOrigin origin)
        {
          throw new NotImplementedException();
        }
        public override void SetLength(long value)
        {
          throw new NotImplementedException();
        }
        public override int ReadByte()
        {
          int returnValue = -1;
          try
          {
            byte b;
            if (_data.TryTake(out b, ReadTimeout, _cts.Token))
            {
              returnValue = (int)b;
            }
          }
          catch (OperationCanceledException)
          {
          }
          return returnValue;
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
          int bytesRead = 0;
          byte b;
          try
          {
            while (bytesRead < count && _data.TryTake(out b, ReadTimeout, _cts.Token))
            {
              buffer[offset + bytesRead] = b;
              bytesRead++;
            }
          }
          catch (OperationCanceledException)
          {
            bytesRead = 0;
          }
          return bytesRead;
        }
        public override void WriteByte(byte value)
        {
          try
          {
            _data.TryAdd(value, WriteTimeout, _cts.Token);  
          }
          catch (OperationCanceledException)
          {
          }
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
          try
          {
            for (int i = offset; i < offset + count; ++i)
            {
              _data.TryAdd(buffer[i], WriteTimeout, _cts.Token);
            }
          }
          catch (OperationCanceledException)
          {
          }
        }
        public override void Close()
        {
          _cts.Cancel();
          base.Close();
        }
        protected override void Dispose(bool disposing)
        {
          base.Dispose(disposing);
          if (disposing)
          {
            _data.Dispose();
          }
        }
      }

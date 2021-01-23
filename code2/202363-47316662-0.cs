    public sealed class ConcatenatedStream : Stream
    {
        List<Stream> streams;
        private long _Position { get; set; }
        public ConcatenatedStream(List<Stream> streams)
        {
            this.streams = streams;
        }
        public override bool CanRead
        {
            get { return true; }
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
            if (streams.Count == 0)
                return 0;
            var startStream = 0;
            var cumulativeCapacity = 0L;
            for (var i = 0; i < streams.Count; i++)
            {
                cumulativeCapacity += streams[i].Length;
                if (_Position < cumulativeCapacity)
                {
                    startStream = i;
                    break;
                }
            }
            var bytesRead = 0;
            var curStream = startStream;
            while (_Position < Length && bytesRead < count && curStream < streams.Count)
            {
                var r = streams[curStream].Read(buffer, offset + bytesRead, count - bytesRead);
                bytesRead += r;
                _Position += r;
                curStream++;
            }
            return bytesRead;
        }
        public override bool CanSeek
        {
            get { return true; }
        }
        public override bool CanWrite
        {
            get { return false; }
        }
        public override void Flush()
        {
            throw new NotImplementedException();
        }
        public override long Length
        {
            get {
                long length = 0;
                for (var i = 0; i < streams.Count; i++)
                {
                    length += streams[i].Length;
                }
                return length;
            }
        }
        public override long Position
        {
            get
            {
                return _Position;
            }
            set
            {
                Seek(Position, SeekOrigin.Begin);
            }
        }
        public override long Seek(long offset, SeekOrigin origin)
        {
            if (origin == SeekOrigin.Begin)
            {
                _Position = offset;
                var prevLength = 0L;
                var cumulativeLength = 0L;
                for (var i = 0; i < streams.Count; i++)
                {
                    cumulativeLength += streams[i].Length;
                    if (offset < cumulativeLength)
                    {
                        streams[i].Seek(offset - prevLength, SeekOrigin.Begin);
                        return _Position;
                    }
                    prevLength = cumulativeLength;
                }
            }
            if (origin == SeekOrigin.Current)
            {
                var newAbs = _Position + offset;
                return Seek(newAbs, SeekOrigin.Begin);
            } 
            else if(origin == SeekOrigin.End)
            {
                var newAbs = Length - offset;
                return Seek(newAbs, SeekOrigin.Begin);
            }
            throw new NotImplementedException();
        }
        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotImplementedException();
        }
    }

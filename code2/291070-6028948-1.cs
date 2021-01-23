    public class MultiStream : Stream
    {
        private readonly byte[] _RandomBytes = "410801dd-6f14-4d68-8e0e-29686d212cb2".Select(c => (byte)c).ToArray();
        private Queue<byte> _RollingBytesRead;
        private Stream _UnderlyingStream;
        private bool UnderlyingEOF = false;
        private bool EOFMarker = false;
        private int BufferedBytesToRead = 0;
        public MultiStream(Stream UnderlyingStream)
            : base()
        {
            _UnderlyingStream = UnderlyingStream;
            _RollingBytesRead = new Queue<byte>(_RandomBytes.Length);
        }
        public override bool CanRead
        {
            get { return !UnderlyingEOF || _UnderlyingStream.CanRead; }
        }
        public override bool CanSeek
        {
            get { return false; }
        }
        public override bool CanWrite
        {
            get { return _UnderlyingStream.CanWrite; }
        }
        public override void Flush()
        {
            _UnderlyingStream.Flush();
        }
        public override long Length
        {
            get { throw new NotSupportedException(); }
        }
        public override long Position
        {
            get
            {
                throw new NotSupportedException();
            }
            set
            {
                throw new NotSupportedException();
            }
        }
        public override int ReadByte()
        {
            if (EOFMarker)
                return -1;
            // This should read the next byte from the underlying stream, check for the random bytes EOF marker, then return the next byte from the buffer
            // If our buffer is smaller than the random bytes and we've not hit the EOF, then we need to fill it
            while (!UnderlyingEOF && _RollingBytesRead.Count < _RandomBytes.Length)
            {
                int BytesRead = _UnderlyingStream.ReadByte();
                if (BytesRead == -1)
                {
                    UnderlyingEOF = true;
                    BufferedBytesToRead = _RollingBytesRead.Count;
                }
                else
                {
                    _RollingBytesRead.Enqueue((byte)BytesRead);
                }
            }
            if (EncounteredEndOfStreamBytes()) // Now check to see if the buffer matches our EOF marker
            {
                // If it does stop now, since we don't want to output any of the EOF marker.
                BufferedBytesToRead = 0;
                _RollingBytesRead.Clear();
                EOFMarker = true;
                return -1;
            }
            else if (UnderlyingEOF) // If we've already encountered the end of the underlying stream and have a buffer,
                                    // then output the next byte since it's not part of the EOF marker, it's part of the stream
            {
                if (BufferedBytesToRead != 0)
                {
                    BufferedBytesToRead--;
                    return _RollingBytesRead.Dequeue();
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                int ByteRead = _UnderlyingStream.ReadByte();
                if (ByteRead == -1)
                {
                    // We've reached the end so we should output the buffer
                    UnderlyingEOF = true;
                    BufferedBytesToRead = _RollingBytesRead.Count;
                    // Recurse once just to avoid repeating code above
                    return ReadByte();
                }
                else
                {
                    byte BufferedByte = _RollingBytesRead.Dequeue();
                    _RollingBytesRead.Enqueue((byte)ByteRead);
                    return BufferedByte;
                }
            }
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
            bool EncounteredEOF = false;
            int BufferIndex = 0;
            while (offset > 0)
            {
                if (ReadByte() == -1)
                {
                    EncounteredEOF = true;
                }
                offset--;
            }
            while (!EncounteredEOF && count > 0)
            {
                // Read the next byte (includes checks for our end of stream marker) and actually returns the buffered byte (not the next underlying stream read byte)
                int ByteRead = ReadByte();
                if (ByteRead == -1)
                {
                    break;
                }
                else
                {
                    buffer[BufferIndex] = (byte)ByteRead;
                    count--;
                    BufferIndex++;
                }
            }
            return BufferIndex;
        }
        private bool EncounteredEndOfStreamBytes()
        {
            if (_RollingBytesRead.Count != _RandomBytes.Length)
                return false;
            byte[] QueueArray = _RollingBytesRead.ToArray();
            for (int i = 0; i < _RandomBytes.Length; i++)
            {
                if (_RandomBytes[i] != QueueArray[i])
                    return false;
            }
            return true;
        }
        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException();
        }
        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            _UnderlyingStream.Write(buffer, offset, count);
        }
        public void WriteStreamSeperator()
        {
            Write(_RandomBytes, 0, _RandomBytes.Length);
        }
        public void AdvanceToNextStream()
        {
            if (UnderlyingEOF)
                throw new InvalidOperationException("No more streams");
            // If we're not currently at an EOF marker, advance until we get to one.
            while (!EOFMarker)
            {
                ReadByte();
            }
            EOFMarker = false;
            _RollingBytesRead.Clear();
        }
    }

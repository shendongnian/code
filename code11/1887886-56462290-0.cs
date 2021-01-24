    public class ReadonlyMemByteStream : Stream
    {
        private readonly ReadOnlyMemory<byte> _buffer;
        private int _offset;
        public ReadonlyMemByteStream(ReadOnlyMemory<byte> buffer)
        {
            _buffer = buffer;
            _offset = 0;
        }
        public override void Flush()
        {
            // NOP
        }
        public override int ReadByte()
        {
            return _buffer.Span[_offset++];
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
            var bufferLength = _buffer.Length - _offset;
            if (count > bufferLength)
                count = bufferLength;
            _buffer.Span.Slice(_offset).CopyTo(new Span<byte>(buffer, offset, count));
            _offset += count;
            return count;
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException();
        }
        public override long Seek(long offset, SeekOrigin origin)
        {
            switch (origin)
            {
                case SeekOrigin.Begin:
                    _offset = (int)offset;
                    break;
                case SeekOrigin.Current:
                    _offset += (int)offset;
                    break;
                case SeekOrigin.End:
                    _offset = _buffer.Length + (int)offset;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(origin), origin, null);
            }
            return _offset;
        }
        public override void SetLength(long value) => throw new NotSupportedException();
        public override bool CanRead => true;
        public override bool CanSeek => true;
        public override bool CanWrite => false;
        public override long Length => _buffer.Length;
        public override long Position
        {
            get => _offset;
            set => _offset = (int)value;
        }
    }
    public class MemByteStream : ReadonlyMemByteStream
    {
        private readonly Memory<byte> _buffer;
        public MemByteStream(Memory<byte> buffer) : base(buffer)
        {
            _buffer = buffer;
        }
        public override void Write(byte[] buffer, int offset, int count)
        {
            new Span<byte>(buffer, offset, count).CopyTo(_buffer.Span.Slice((int)Position));
            Position += count;
        }
        public override bool CanWrite => true;
    }

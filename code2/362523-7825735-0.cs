    public class FastFileStream : FileStream
    {
        private long _position;
        private long _length;
        public FastFileStream(string path, FileMode fileMode) : base(path, fileMode)
        {
            _position = base.Position;
            _length = base.Length;
        }
        public override long Length
        {
            get { return _length; }
        }
        public override long Position
        {
            get { return _position; }
            set
            {
                base.Position = value;
                _position = value;
            }
        }
        public override long Seek(long offset, SeekOrigin seekOrigin)
        {
            switch (seekOrigin)
            {
                case SeekOrigin.Begin:
                    _position = offset;
                    break;
                case SeekOrigin.Current:
                    _position += offset;
                    break;
                case SeekOrigin.End:
                    _position = Length + offset - 1;
                    break;
            }
            return base.Seek(offset, seekOrigin);
        }
        public override int Read(byte[] array, int offset, int count)
        {
            _position += count;
            return base.Read(array, offset, count);
        }
        public override int ReadByte()
        {
            _position += 1;
            return base.ReadByte();
        }
    }

    public class WaveProviderToWaveStream : WaveStream
    {
        private readonly IWaveProvider source;
        private long position;
        public WaveProviderToWaveStream(IWaveProvider source)
        {
            this.source = source;
        }
        
        public override WaveFormat WaveFormat
        {
            get { return source.WaveFormat;  }
        }
        /// <summary>
        /// Don't know the real length of the source, just return a big number
        /// </summary>
        public override long Length
        {
            get { return Int32.MaxValue; } 
        }
        public override long Position
        {
            get
            {
                // we'll just return the number of bytes read so far
                return position;
            }
            set
            {
                // can't set position on the source
                // n.b. could alternatively ignore this
                throw new NotImplementedException();
            }
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
            int read = source.Read(buffer, offset, count);
            position += read;
            return read;
        }
    }

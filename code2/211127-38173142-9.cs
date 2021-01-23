    sealed class LineReader : IDisposable
    {
        public static LineReader Create(Stream stream)
        {
            return new LineReader(stream, ownsStream: false);
        }
    
        public static LineReader Create<TStream>(ref TStream stream) where TStream : Stream
        {
            try     { return new LineReader(stream, ownsStream: true); }
            finally { stream = null;                                   }
        }
    
        private LineReader(Stream stream, bool ownsStream)
        {
            this.stream = stream;
            this.ownsStream = ownsStream;
        }
    
        private Stream stream; // note: must not be exposed via property, because of rule (2)
        private bool ownsStream;
    
        public void Dispose()
        {
            if (ownsStream)
            {
                stream?.Dispose();
            }
        }
    
        public bool TryReadLine(out string line)
        {
            throw new NotImplementedException(); // read one text line from `stream` 
        }
    }

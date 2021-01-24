    public class Source : IDisposable
    {
        private readonly Stream _stream;
        private readonly bool _leaveOpen;
    
        private Source(Stream stream, bool leaveOpen)
        {
            _stream = stream;
            _leaveOpen = leaveOpen;
        }
    
        public Source(FileStream fileStream) : this(fileStream, true)
        {
    
        }
    
        public Source(string fileName) : this(new FileStream(fileName, FileMode.Open), false)
        {
            
        }
    
        public void Dispose()
        {
            if (!_leaveOpen)
            {
                _stream?.Dispose();
            }
        }
    }

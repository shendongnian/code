    public class BetterStreamWriter : StreamWriter
    {
        private readonly bool _itShouldDisposeStream;
    
        public BetterStreamWriter(string filepath)
            :base(filepath)
        {
            _itShouldDisposeStream = false;
        }
    
        public BetterStreamWriter(Stream stream)
            : base(stream)
        {
            _itShouldDisposeStream = true;
        }
    
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing && _itShouldDisposeStream);
        }
    }

    public class BetterStreamWriter : StreamWriter
    {
        private readonly bool _itShouldDisposeStream;
    
        public BetterStreamWriter(string filepath)
            :base(filepath)
        {
            _itShouldDisposeStream = true;
        }
    
        public BetterStreamWriter(Stream stream)
            : base(stream)
        {
            _itShouldDisposeStream = false;
        }
    
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing && _itShouldDisposeStream);
        }
    }

    public class ExampleFile
    {
        protected Stream _stream;  // no longer private, so the inherited
        protected long _baseoffset; //classes can access them
    
        public ExampleFile(Stream input)
        {
            _stream = input;
            _baseoffset = input.Position;
        }
    
        public void SeekTo(long offset)
        {
            _stream.Seek(offset + _baseoffset, SeekOrigin.Begin);
        }
    }

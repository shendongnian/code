    public class Example : Stream
    {
        private Stream _underlying;
        public Example(Stream underlying) { _underlying = underlying; }
        // Do the following for all the methods in Stream
        public override int Read(...) { return _underlying.Read(...); }
    }

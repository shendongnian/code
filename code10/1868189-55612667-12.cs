    class ReaderWrapper:IDataReader
    {
        private readonly IDataReader _inner ;
        public ReaderWrapper(IDataReader inner)
        {
            _inner = inner;
        }
    }

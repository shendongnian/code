    interface IReaderWrapper:IDataReader
    {
        //Gives access to the wrapped reader in the concrete classes
        abstract IDataReader Inner();
        override object this[int i] => Inner()[i];
        override object this[string name] => Inner()[name];
        override int Depth => Inner().Depth;
        override bool IsClosed => Inner().IsClosed;
        ...
    }
    class SplitterWrapper:IReaderWrapper
    {
        private readonly IDataReader _inner ;
        public SplitterWrapper(IDataReader inner)
        {
            _inner = inner;
        }
        IDataReader Inner()=> _inner;
        string[] _values;
        public object this[int i] => _values[i];
        ...
    }

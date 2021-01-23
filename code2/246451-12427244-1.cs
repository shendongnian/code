    public struct FancyWrappedEnumerable<TItems,TEnumerator,TDataSource> : IEnumerable<TItems> where TEnumerator : IEnumerator<TItems>
    {
        TDataSource _dataSource;
        Func<TDataSource,TEnumerator> _convertor;
        public FancyWrappedEnumerable(TDataSource dataSource, Func<TDataSource, TEnumerator> convertor)
        {
            _dataSource = dataSource;
            _convertor = convertor;
        }
        public TEnumerator GetEnumerator()
        {
            return _convertor(_dataSource);
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _convertor(_dataSource);
        }
    }

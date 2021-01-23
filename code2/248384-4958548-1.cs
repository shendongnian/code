    public class IndexReaderProxy
    {
        private IndexReader _indexReader;
        private readonly object _indexReaderLock = new object();
        public IndexReaderProxy(Directory directory, bool readOnly)
        {
            _indexReader = IndexReader.Open(directory, readOnly);
        }
        public IndexReader GetCurrentIndexReader()
        {
            ReopenIndexReaderIfNotCurrent();
            return _indexReader;
        }
        private void ReopenIndexReaderIfNotCurrent()
        {
            if (_indexReader.IsCurrent()) return;
            lock (_indexReaderLock)
            {
                if (_indexReader.IsCurrent()) return;
                var newIndexReader = _indexReader.Reopen();
                _indexReader.Close();
                _indexReader = newIndexReader;
            }
        }
    }

    public class QuoteStore : IDisposable
    {
        private readonly ReaderWriterLockSlim _mutex = new ReaderWriterLockSlim();
        private readonly List<Quote> _quotes = new List<Quote>();
        
        public ReadOnlyCollection<Quote> GetQuotes()
        {
          _mutex.EnterReadLock();
          try
          {
            return _quotes.ToReadOnly();
          }
          finally
          {
            _mutex.ExitReadLock();
          }
        }
        public void AddQuote()
        {
          _mutex.EnterWriteLock();
          try
          {
            _quotes.Add(quote);
          }
          finally
          {
            _mutex.ExitWriteLock();
          }
        }
        public void Dispose() 
        {
            _mutex.Dispose();
        }
    }

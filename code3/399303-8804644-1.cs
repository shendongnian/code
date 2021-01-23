    public class QuoteStore
    {
        private readonly List<Quote> _quotes = new List<Quote>();
        private readonly object _mutex = new object();
        public ReadOnlyCollection<Quote> GetQuotes()
        {
          lock (_mutex)
          {
            return _quotes.ToReadOnly();
          }
        }
        public void AddQuote()
        {
          lock (_mutex)
          {
            _quotes.Add(quote);
          }
        }
    }

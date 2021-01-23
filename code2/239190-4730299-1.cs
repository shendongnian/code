    public class Indexer<TKey, TValue>
    {
        private Func<TKey, TValue> func;
        public Indexer(Func<TKey, TValue> func)
        {
            if (func == null)
                throw new ArgumentNullException("func");
            this.func = func;
        }
        public TValue this[TKey key]
        {
            get { return func(key); }
        }
    }
    class Library
    {
        public Indexer<string, Book> Books { get; private set; }
        public Indexer<string, DateTime> PublishingDates { get; private set; }
        public Library()
        {
            Books = new Indexer<string, Book>(GetBookByName);
            PublishingDates = new Indexer<string, DateTime>(GetPublishingDate);
        }
        private Book GetBookByName(string bookName)
        {
            // ...
        }
        private DateTime GetPublishingDate(string bookName)
        {
            return GetBookByName(bookName).PublishingDate;
        }
    }

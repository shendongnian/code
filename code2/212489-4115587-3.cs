    public interface IBlogRepository
    {
        ISession Session { get; set; }
        IEnumerable<Entry> GetEntries(int pageId, int pageCount);
        IEnumerable<Entry> GetEntriesWithSession(ISession session,
            int pageId, int pageCount);
    }
    class BlogDatabase : IBlogRepository
    {
        public ISession Session { Get; set; }
        public IEnumerable<Entry> GetEntries(int pageId, int pageCount)
        {
            var query = Session.CreateQuery ...
        }
        public IEnumerable<Entry> GetEntries(ISession session, int pageId, int pageCount)
        {
            var query = session.CreateQuery ...
        }
    }
    class BlogFile : IBlogRepository
    {
        // ISession has to abstract a file handle.  We're still okay
        // ...
    }
    class BlogInMemory : IBlogRepository
    {
        // ISession abstracts nothing.
        // Maybe a lock, at best, but the abstraction is still breaking down
        // ...
    }

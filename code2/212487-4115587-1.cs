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

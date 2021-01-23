    public interface IBlogRepository
    {
        IEnumerable<Entry> GetEntries(int pageId, int pageCount);
    }
    class BlogDatabase : IBlogRepository
    {
        public BlogDatabase(ISession session)
        {
            this.session = session;
        }
        public IEnumerable<Entry> GetEntries(int pageId, int pageCount)
        {
            // Not that you should implement your queries this way...
            var query = session.CreateQuery("from BlogEntry");
            return query.Skip(pageId * pageCount).Take(pageCount);
        }
        private ISession session;
    }

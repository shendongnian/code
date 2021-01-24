    public class FakeBookstoreContext : IDisposable
    {
        public BookstoreContext `enter code here`m_context;
        public FakeBookstoreContext()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder<BookstoreContext>()
                .UseSqlite(connection)
                .Options;
            m_context = new BookstoreContext(options);
            m_context.Database.EnsureCreated();
        }
        public void Dispose()
        {
            m_context.Database.EnsureDeleted();
            m_context.Dispose();
        }
    }

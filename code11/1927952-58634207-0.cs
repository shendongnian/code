    connectionString = "mongodb://localhost:27017";
    client = new MongoClient(connectionString);
    database = client.GetDatabase("authors_and_books");      // rename as appropriate
    collection = database.GetCollection<Author>("authors");  // rename as appropriate
    public class Author // Parent class
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LifeExpectancy { get; set; }
        public IList<Book> Books { get; set; }
        = new List<Book>();
    }
    public class Book // Child class
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid ParentId { get; set; }
    }

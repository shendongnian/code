     [ContentProperty("Books")]
     public class Library {
       private readonly List<Book> m_books = new List<Book>();
       public List<Book> Books { get { return m_books; } }
     }
     public class Book
     {
        [DefaultValue(string.Empty)]
        public string Title { get; set; }
        [DefaultValue(string.Empty)]
        public string Description { get; set; }
        [DefaultValue(string.Empty)]
        public string Author { get; set; }
     }

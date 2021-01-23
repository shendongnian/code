    public class Book
    {
        public int ID {get; set;}
        public string Title {get; set;}
        public Author FirstAuthor {get; set;}
        public Author SecondAuthor {get; set;}
    }
    public class Author
    {
        public int ID {get; set;}
        public string Name {get; set;}
        
        public virtual ICollection<Book> BooksAsFirstAuthor {get; set;}
        public virtual ICollection<Book> BooksAsSecondAuthor {get; set;}
    }

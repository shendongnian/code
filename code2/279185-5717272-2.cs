    public class Book
    {
        public int ID {get; set;}
        public string Title {get; set;}
        [InverseProperty("BooksAsFirstAuthor")]
        public Author FirstAuthor {get; set;}
        [InverseProperty("BooksAsSecondAuthor")]
        public Author SecondAuthor {get; set;}
    }
    public class Author
    {
        public int ID {get; set;}
        public string Name {get; set;}
        
        [InverseProperty("FirstAuthor")]
        public virtual ICollection<Book> BooksAsFirstAuthor {get; set;}
        [InverseProperty("SecondAuthor")]
        public virtual ICollection<Book> BooksAsSecondAuthor {get; set;}
    }

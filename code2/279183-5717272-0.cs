    public class Book
    {
        public int ID {get; set;}
        public string Title {get; set;}
        [InverseProperty("Books")]
        public Author Author {get; set;}
    }
    public class Author
    {
        public int ID {get; set;}
        public string Name {get; set;}
        
        [InverseProperty("Author")]
        public virtual ICollection<Book> Books {get; set;}
    }

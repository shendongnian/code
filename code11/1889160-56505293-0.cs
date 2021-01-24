    public class Book
    {
        [Key]
        public int Id { get; set; }
        public int LibraryId { get; set; }
        public string Title { get; set; }
        public virtual Bookshelf Bookshelf { get; set; }
        [ForeignKey("LibraryId")]
        public virtual Library Library { get; set; }
    }
    public class Bookshelf
    {
        [Key]
        public int Id { get; set; }
        public string Color { get; set; }
    }
    public class Library
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }

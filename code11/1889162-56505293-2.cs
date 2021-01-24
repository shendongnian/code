    public class Library
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
    public class Bookshelf
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Color { get; set; }
    }
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public int LibraryId { get; set; }
        public string Title { get; set; }
        public int BookshelfId { get; set; }
        [ForeignKey("BookshelfId")]
        public virtual Bookshelf Bookshelf { get; set; }
        [ForeignKey("LibraryId")]
        public virtual Library Library { get; set; }
    }
   

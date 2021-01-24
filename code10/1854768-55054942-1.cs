    public class Author
    {
        public string Name { get; set; }
        public DateTime Born { get; set; }
        public DateTime? Deceased { get; set; }
    }
    public class Book
    {
        public string Title { get; set; }
        public List<Author> Authors { get; } = new List<Author>();
        public decimal Price { get; set; }
    }

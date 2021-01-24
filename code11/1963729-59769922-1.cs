    public class Books
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }
        public string BookName { get; set; }
        public double BookPrice { get; set; }
        public string Author { get; set; }
    }
    public class ChangeLog
    {
        public string Property { get; set; }
        public string oldValue { get; set; }
        public string newValue { get; set; }
        public DateTime dateOfChange { get; set; }
    }

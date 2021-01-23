    public class Book
    {
        [Key]
        public int ID { get; set; }
        public String Name { get; set; }
        public DateTime DatePublished { get; set; }
    
        // I don't need this one in SL4
        [Exclude]
        public BookInfo Info { get; set; }
    }

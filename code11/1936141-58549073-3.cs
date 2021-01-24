    public class Book
    {
        public string Name { get; set; }
        public DateTime CompletedDate { get; set; }
    }
    List<Book> lstBooks = new List<Book>
    {
        new Book { Name = "ABC", CompletedDate = DateTime.Now },
        new Book { Name = "1ABC", CompletedDate = DateTime.Now },
        new Book { Name = "XYZ", CompletedDate = DateTime.Now },
        new Book { Name = "2XYZ", CompletedDate = DateTime.Now },
        new Book { Name = "123ABC", CompletedDate = DateTime.Now },
    };
     

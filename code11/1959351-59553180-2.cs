    public class Book
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime PublishDate { get; set; }
    }
    var PropertyList = PropertiesFromType<Book>(MyListOfBooks);

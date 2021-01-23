    public class Book
    {
        public string Title { get; set; }
        
        [XmlArrayItem("AuthorName")]
        public string[] Authors { get; set; }
    }

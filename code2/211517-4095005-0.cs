    public class Books
    {
        [XmlElement("Book")]
        public List<Book> BookList;
    }
    
    public class Book
    {
        [XmlAttribute]
        public string Title;
        [XmlAttribute]
        public string Description;
        [XmlAttribute]
        public string Author;
        [XmlAttribute]
        public string Publisher;
    }
    
    class Program
    {
        static void Main()
        {
            var books = new Books
            {
                BookList = new List<Book>(new[] 
                {
                    new Book 
                    {
                        Title = "t1",
                        Description = "d1"
                    },
                    new Book 
                    {
                        Author = "a2",
                        Description = "d2"
                    },
                    new Book 
                    {
                        Author = "a3",
                        Title = "t3",
                        Publisher = "p3"
                    },
                })
            };
    
            var serializer = new XmlSerializer(books.GetType());
            serializer.Serialize(Console.Out, books);
        }
    }

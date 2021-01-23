    public class Book
    {
        public string Title;
        public string Author;
    }
    public class MyBookType : Book { }
    [XmlInclude(typeof(MyBookType))]
    [XmlRoot("Books")]
    public class Books : List<Book> { }
    public void Run()
    {
        var b =  new Books();
        b.Add(new MyBookType
            {
                Title = "The Art of War",
                Author = "Sun Tzu"
            });
        b.Add(new MyBookType
            {
                Title = "Great Expectations",
                Author = "Charles Dickens"
            });
        var s = new XmlSerializer(typeof(Books));
        s.Serialize(Console.Out, b);
    }

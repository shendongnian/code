    public class Book
    {
        public Book(IBookShop bookShop)
        {
            TheStop = bookShop;
        }
        [XmlIgnore]
        public IBookShop TheShop { get; set; }
    }
    public interface IBookShop 
    {
        void SomeMethod();
    }
    public class BookShop : IBookShop
    {
        list<Book> Books = new list<Book>();
        public void SomeMethod()
        {
        }
    }

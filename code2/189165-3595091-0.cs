    public class BookstoreSingleton {
    
        private static readonly BookstoreSingleton instance = new BookstoreSingleton()
        public BookstoreSingleton Instance { return instance; }
    
        public Book Book { get { return this.book; } }
    }

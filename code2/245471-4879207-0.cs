    public class BookSummary
    {
        public int BookID {get; set; }
        public int BookExampleID {get; set; }
        public bool StockAvailable {get; set; }
        public string Title {get; set; }
    }
    var books = from b in _myIbokexamples Repository.RetrieveAllBookExample().Include("Book") // I'm assuming that's there, lol
                select new BookSummary
                {
                    BookID = b.BookID,
                    BookExampleID = b.BookExampleID,
                    StockAvailable = b.OrderDetailID == null,
                    Title = b.Book.Title
                };

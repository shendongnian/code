    public class BookExplorerViewModel : DependencyObject
    {   
        private IBookListProvider bookProvider;
        private bool canQuery = true;
        public ObservableCollection<BookModel> Books { get; set; }
        public string Title { get; set; }
        public string ID { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public BookExplorerViewModel() {
            bookProvider = new BookListProvider();            
            Books = new ObservableCollection<BookModel>(); 
        }
        public void ExecuteBookQuery() {
            Books.Clear();
            foreach(BookModel book in bookProvider.DocumentsQuery("temp")){
                Books.Add(book);
            }
        }
    }

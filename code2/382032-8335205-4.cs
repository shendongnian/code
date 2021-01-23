    public class BookViewModel : BaseViewModel
    {
    	public BookViewModel()
        {
           Books = new ObservableCollection<Book>();
        }
    
        public ObservableCollection<Book> Books { get; set; }
    
        private Book _selectedBook; 
        public Book SelectedBook 
        { 
           get { return _selectedBook; } 
           set
           {
              _selectedBook = value;
              NotifyPropertyChanged(() => SelectedBook); 
           }
        }
    }

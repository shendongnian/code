    public MainViewModel()
    {
        SubmitCommand = new DelegateCommand<object>(AddBook);
        SaveCommand = new DelegateCommand<object>(SaveResults);
        LoadCommand = new DelegateCommand<object>(LoadResults);
        Books = new ObservableCollection<BookViewModel>();
        SelectedBook = new BookViewModel();
        LoadResults();
    }

    public MainWindow()
    {
        InitializeComponent();
        WordsCollectionView = CollectionViewSource.GetDefaultView(words);
        WordsCollectionView.Filter = FilterResult;
        var listCollectionView = WordsCollectionView as ListCollectionView;
        if (listCollectionView != null)
            listCollectionView.CustomSort = new CustomSorter(this);
        DataContext = this;
    }
    private class CustomSorter : IComparer
    {
        private readonly MainWindow _window;
        public CustomSorter(MainWindow window)
        {
            _window = window;
        }
        public int Compare(object x, object y)
        {
            int a = x?.ToString().IndexOf(_window.FilterString) ?? -1;
            int b = y?.ToString().IndexOf(_window.FilterString) ?? -1;
            return a.CompareTo(b);
        }
    }

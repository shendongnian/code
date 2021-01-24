    private ObservableCollection<CategoryCounter> categories;
    public ObservableCollection<CategoryCounter> Categories
    {
        get { return categories; }
        set
        {
            categories = value;
            NotifyPropertyChanged(nameof(Categories));
        }
    }

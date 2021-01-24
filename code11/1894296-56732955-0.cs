    public static IEnumerable<Category> TestCategories
    {
        get
        {
            yield return new Category { CategoryTitle = "title 1" };
            yield return new Category { CategoryTitle = "title 2" };
        }
    }
    ...
    public MainViewModel()
    {
        Categories = new ObservableCollection<Category>(TestCategories);
    }

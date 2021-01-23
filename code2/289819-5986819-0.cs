    private static Lazy<IEnumerable<Category>> _allCategories
        = new Lazy<IEnumerable<Category>>(() => /* Db call to populate */);
    public static IEnumerable<Category> AllCategories 
    { 
        get { return _allCategories.Value; } 
    }

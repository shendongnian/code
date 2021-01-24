    public ICollectionView FilteredNames { get; set; }
    IList<string> names = new List<string>() { "Jerry", "Joey", "Roger", "Raymond", "Jessica", "Mario", "Jonathan" };
    public VM()
    {
        FilteredNames = CollectionViewSource.GetDefaultView(names);
        FilteredNames.Filter = (obj) => 
        {
            if (!(obj is string str))
                return false;
            return str.Contains(filter);
        };
    }
        
    string filter = "";
    public string Filter
    {
        get 
        {
            return this.filter;
        }
        set 
        {
            this.filter = value;
            FilteredNames?.Refresh();
        }
    }

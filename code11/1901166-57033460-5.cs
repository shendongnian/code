    private ObservableCollection<PathItem> pathsCollection;
    public ObservableCollection<PathItem> PathsCollection
    {
    	get { return pathsCollection ?? (pathsCollection = new ObservableCollection<PathItem>()); }
    }

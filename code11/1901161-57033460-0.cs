    private ObservableCollection<string> pathsCollection;
    public ObservableCollection<string> PathsCollection
    {
    	get { return pathsCollection ?? (pathsCollection = new ObservableCollection<string>()); }
    }

    public AppSettings()
    {
        InitializeMyList();​
    }​
        
    private async void InitializeMyList() 
    {
        myLists = await LoadFromFile<ObservableCollection<String>>("");​
    }
    private ObservableCollection<string> myLists = new ObservableCollection<string>();
    public ObservableCollection<string> MyLists 
    {
        get {
            return myLists;
        }
        set {
                ......
        }
    }
 

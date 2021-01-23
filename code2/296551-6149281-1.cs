    ObservableCollection<string> logItems = new ObservableCollection<string>();
    
    public ObservableCollection<string> LogItems
    {
      get { return _logItems; }
    }
    
    // add items as they are logged
    public AddToLog(string message)
    {
      logItems.Add(message);
    }

    tabControl.Dispatcher.Invoke calls below function with dataSoruce result it gets 
    List<string> result = null;
    tabControl.Dispatcher.Invoke((Action<IEnumerable<string>>)ProcessResult, result);
    public  void ProcessResult(IEnumerable<string> datasource)
    {
       //this is where you do creating TabItem and assigning data source to it and adding to TabControl. 
                
    }

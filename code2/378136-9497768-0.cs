    class DummyClass : INotifyPropertyChanged
    {
    
    	private MyItem _myItem;
    	public MyItem MyItem
    	{
    		get { return _myItem; }
    		set { _myItem = value; NotifyPropertyChanged("MyItem"); }
    	}
    
    	private IEnumerable<MyItem> _myItems;
    	public IEnumerable<MyItem> MyItems
    	{
    		get { return _myItems; }		
    	}
    	
    	public void FillWithItems()
    	{
    		/* Some logic */
    		_myItems = ...
    		
    		NotifyPropertyChanged("MyItems");
    		
    		/* This automatically selects the first element */
    		MyItem = _myItems.FirstOrDefault();
    	}
    
    	#region INotifyPropertyChanged Members
    	public event PropertyChangedEventHandler PropertyChanged;
    
    	private void NotifyPropertyChanged(string value)
    	{
    		if (PropertyChanged != null)
    		{
    			PropertyChanged(this, new PropertyChangedEventArgs(value));
    		}
    	}
    	#endregion
    }

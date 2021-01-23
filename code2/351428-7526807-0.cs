    class UIManager: INotifyPropertyChaged
    {
            
    	private ObservableCollection<ItemsList> _displayItem;
            
            public ObservableCollection<ItemsList> DisplayItem
            {
               get
               {
                  return _displayItem;
               }
               set
               {
                  if(value != _displayItem)
                  {
                     _displayItem=value;
                     NotifyPropertyChanged("DisplayItem");
                  }
               }
            
            public UIManager()
            {
               DisplayItem = new ObservableCollection<ItemsList>();
               DisplayCat(DataManager.getInstance().displayName, DataManager.getInstance().icons);
            }
            
            public void DisplayCat(string[] DisplayNames, BitmapImage[] Icon)
            {
                    ObservableCollection<ItemsList> tmpColl = new ObservableCollection<ItemsList>();        
             
    		for (int i = 0; i < DataManager.getInstance().count; i++)
            	{
                		tmpColl.Add(new ItemsList { Widget = DisplayNames[i], Icon = Icon[i] });
            	}
     		DisplayItem = tmpColl;
        	}
    
    	public event PropertyChangedEventHandler PropertyChanged;
    
    	private void NotifyPropertyChanged(String info)
    	{
        		if (PropertyChanged != null)
        		{
            		PropertyChanged(this, new PropertyChangedEventArgs(info));
        		}
    	}
    
    }

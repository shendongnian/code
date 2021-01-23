    public class Movie : INotifyPropertyChanged
    {
    	private string _name = String.Empty;
    	public string Name
    	{
    		get { return _name; }
    		set
    		{
    			if (_name != value)
    			{
    				_name = value;
    				NotifyPropertyChanged("Name");
    			}
    		}
    	}
    	//...All the other properties (the same way)...
    
    	public event PropertyChangedEventHandler PropertyChanged;
    
    	public void NotifyPropertyChanged(string propertyName)
    	{
    		if (PropertyChanged != null)
    		{
    			PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
    		}
    	}
    }

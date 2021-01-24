    public class Dates : INotifyPropertyChanged
    {
    	private DateTime _myDate;
    	public DateTime MyDate
    	{
    		get
    		{
    			return _myDate;
    		}
    		set
    		{
    			_myDate = value;
    			// With this NotifyPropertyChanged it will raise the event that it has changed and update the information where there is a binding for this property
    			NotifyPropertyChanged("MyDate");
    		}
    	}
    	
    	public event PropertyChangedEventHandler PropertyChanged;
    	public void NotifyPropertyChanged(string name)
    	{
    		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    	}
    }

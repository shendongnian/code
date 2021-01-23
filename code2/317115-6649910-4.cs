    public class PropertyChangedNotifier : INotifyPropertyChanged
    {
    	public event PropertyChangedEventHandler PropertyChanged
    	{
    		add { mPropertyChanged += value; }
    		remove { mPropertyChanged -= value; }
    	}
    		
    	protected virtual void RaisePropertyChanged(string aPropertyName)
    	{
    		PropertyChangedEventHandler handler = mPropertyChanged;
    		if (handler != null)
    		{
    			var e = new PropertyChangedEventArgs(aPropertyName);
    			handler(this, e);
    		}
    	}
    		
    	private PropertyChangedEventHandler mPropertyChanged;
    }

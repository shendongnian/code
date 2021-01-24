    public class PathItem : INotifyPropertyChanged
    {
    	private string path;
    	public string Path
    	{
    		get { return path; }
    		set
    		{
    			path = value;
    			OnPropertyChanged();
    		}
    	}
    
    	public event PropertyChangedEventHandler PropertyChanged;
    	protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    	{
    		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    	}
    }

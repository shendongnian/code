    public class Address : INotifyPropertyChanged
    {
    	private string _Name;
    	public string Name
    	{
    		get { return _Name; }
    		set
    		{
    			if (_Name != value) {
    				_Name = value;
    				OnPropertyChanged("Name");
    			}
    		}
    	}
    
    	private string _City;
    	public string City
    	{
    		get { return _City; }
    		set
    		{
    			if (_City != value) {
    				_City = value;
    				OnPropertyChanged("City");
    				OnPropertyChanged("CityZip");
    			}
    		}
    	}
    
    	private int? _Zip;
    	public int? Zip
    	{
    		get { return _Zip; }
    		set
    		{
    			if (_Zip != value) {
    				_Zip = value;
    				OnPropertyChanged("Zip");
    				OnPropertyChanged("CityZip");
    			}
    		}
    	}
    
    	public string CityZip { get { return Zip.ToString() + " " + City; } }
    
    	public override string ToString()
    	{
    		return Name + "," + CityZip;
    	}
    
    	#region INotifyPropertyChanged Members
    
    	public event PropertyChangedEventHandler PropertyChanged;
    
    	private void OnPropertyChanged(string propertyName)
    	{
    		var handler = PropertyChanged;
    		if (handler != null) {
    			handler(this, new PropertyChangedEventArgs(propertyName));
    		}
    	}
    
    	#endregion
    }

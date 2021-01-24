    public class Salutation : INotifyPropertyChanged
    {
    	private string identifier = null;
    	private string name = null;
    	private bool selected = false;
    
    	public event PropertyChangedEventHandler PropertyChanged;
    
    	[JsonProperty(PropertyName = "identifier", NullValueHandling = NullValueHandling.Ignore)]
    	public string Identifier
    	{
    		get
    		{
    			return identifier
    		}
    
    		set
    		{
    			identifier = value;
    			OnPropertyChanged();
    		}
    	}
    
    	[JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
    	public string Name
    	{
    		get
    		{
    			return name;
    		}
    
    		set
    		{
    			name = value;
    			OnPropertyChanged();
    		}
    	}
    
    	[JsonProperty(PropertyName = "selected", NullValueHandling = NullValueHandling.Ignore)]
    	public bool Selected
    	{
    		get
    		{
    			return selected;
    		}
    		set
    		{
    			selected = value;
    			OnPropertyChanged();
    		}
    	}
    
    	public override int GetHashCode() => (Identifier).GetHashCode();
    
    	public bool Equals(Salutation other) => (Identifier) == (other?.Identifier);
    
    	public override string ToString()
    	{
    		return Identifier;
    	}
    
    	public override bool Equals(object obj)
    	{
    		if (!(obj is Salutation item))
    		{
    			return false;
    		}
    
    		return Equals(item);
    	}
    
    	public static bool operator ==(Salutation salutation1, Salutation salutation2)
    	{
    		if (ReferenceEquals(salutation1, salutation2))
    		{
    			return true;
    		}
    
    		if (ReferenceEquals(salutation1, null) || ReferenceEquals(salutation2, null))
    		{
    			return false;
    		}
    
    		return salutation1.Equals(salutation2);
    	}
    
    	public static bool operator !=(Salutation salutation1, Salutation salutation2)
    	{
    		return !(salutation1 == salutation2);
    	}
    
    	protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null) => 
    		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

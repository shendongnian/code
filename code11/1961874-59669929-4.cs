    public class CompareObject
    {
    	public string prop { get; set; }
        
        public new bool Equals(object o)
    	{
    		if (o.GetType() == typeof(CompareObject))
    			return this.prop == ((CompareObject)o).prop;	
    		return this.GetHashCode() == o.GetHashCode();
    	}
    }    

    public class Product
    {
    	protected string _features; //this is where we'll store the pipe-delimited string
    	public List<string> Features {
    		get
    		{
    			if(string.IsNullOrEmpty(_features)
    				return new List<String>();
    			return _features.Split(new[]{"|"}, StringSplitOptions.None).ToList();
    		}
    		set
    		{
    			_features = string.Join("|",value);
    		}
    	}
    }
    
    public class ProductMapping : ClassMap<Product>
    {
    	protected ProductMapping()
    	{
    		Map(x => x.Features).CustomType(typeof(string)).Access.CamelCaseField(Prefix.Underscore);
    	}
    }

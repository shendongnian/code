    public class MyClass
    {
    	public int ID {get; set;}
    	public int Year {get; set;}
    	public string X {get; set;}
    }
    
    public class MyClassEqualityComparer : 	IEqualityComparer<MyClass>
    {
    	public bool Equals(MyClass x, MyClass y)
    	{
    		return x.Year == y.Year;
    	}
    	
    	public int GetHashCode(MyClass obj)
    	{
    		return obj.ToString().ToLower().GetHashCode();
    	}
    }
    
    void Main()
    {
    	var fake = new List<MyClass> {
    		  new MyClass { ID = 1, Year = 2011, X = "" }
    		, new MyClass { ID = 2, Year = 2012, X = "" }
    		, new MyClass { ID = 3, Year = 2013, X = "" }
    	};
    	
    	var real = new List<MyClass> {
    		  new MyClass { ID = 35, Year = 2011, X = "Information" }
    		, new MyClass { ID = 77, Year = 2013, X = "Important" }
    	};
    
    	var merged = real.Union(fake, new MyClassEqualityComparer());
    }

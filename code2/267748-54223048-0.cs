    void Main()
    {
    	var dog = MyValues.Dog.ToId();	
    	var cat = MyValues.Cat.ToId();	
    	var bird = MyValues.Bird.ToId();	
    }
    
    public enum MyValues
    { 
    	Dog,
    	Cat,
    	Bird
    }
    
    public static class Functions
    {
    	public static Guid ToId(this MyValues value)
    	{
    		switch (value)
    		{
    			case MyValues.Dog:
    				return Guid.Parse("6d139d6a-2bfa-466d-a9a5-c6e82f9abf51");
    			case MyValues.Cat:
    				return Guid.Parse("AA139d6a-2bfa-466d-a9a5-c6e82f9abf51");
    			case MyValues.Bird:
    				return Guid.Parse("BB139d6a-2bfa-466d-a9a5-c6e82f9abf51");
    			default:
    				throw new InvalidDataException();
    		}
    	}
    }

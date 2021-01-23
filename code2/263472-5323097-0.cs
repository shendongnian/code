    class Person
    {
    	private string name;
    
    	public string Name
    	{
    		get
    		{
    			return name;
    		}
    		set
    		{
    			name = value;
    		}
    	}
    
    	public Person(string name)
    	{
    		this.name = name; 	// "this" is necessary here to disambiguate between the name passed in and the name field.
    		this.Name = name;	// "this" is not necessary, as there is only one Name in scope.
    		Name = name; 		// See - works without "this".
    	}
    }

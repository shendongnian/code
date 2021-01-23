    // Parent class
    class Parent
    {
    	public Parent()
            {
    		// Paremeterless constructor
            }
            
            public Parent(string a, int b)
            {
    		// Paremterised constructor
            }       
    }
            
            
    // Child class       
    class Child : Parent
    {
    	public Child()
                    :base("hi", 10)
            {
    	    // Parameterized constructor of the base class is invoked   
            }
    }

    public class Validator
    {
    	public string SomeState { get; set; }
    	
    	public Validator(string someState)
    	{
    		SomeState = someState;
    	}
    
    	public bool IsValid(string input)
    	{
    		return input == SomeState;
    	}
    }
    // assume your 'input' being validated is "foo"
    GetContent((new Validator("foo")).IsValid); // IsValid returns true
    GetContent((new Validator("bar")).IsValid); // IsValid returns false
 

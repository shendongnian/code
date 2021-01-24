    public class User
    {
    	public string FirstName{get;set;}
    	public string LastName{get;set;}
    	public int Age{get;set;}
    	
    	public void Deconstruct(out string fName,out string lName,out int age)
    	{
    		fName = FirstName;
    		lName = LastName;
    		age = Age;
    	}
    }

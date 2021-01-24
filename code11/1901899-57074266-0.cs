    public class SomePerson
    {
    	//Class variables
    	private string _firstName;
    	private string _lastName;
    
    	//Constructor
    	public SomePerson(string firstName, string lastName)
    	{
    		this._firstName = firstName;
    		this._lastName = lastName;
    	}
    
    	//Property
    	public string FullName
    	{
    		get
    		{
    			return string.Format("{0} {1}", this._firstName, this._lastName);
    		}
    	}
    
    	//Method
    	public string Hello()
    	{
    		string myText = "Hello "+FullName+", it is nice to meet you.";
    		return myText;
    	}
    }

    void Main()
    {	
    	Console.WriteLine(new Key().ToString());
    }
    
    public interface IKey 
    {
        string ToString(string dummy = null);
    }
    
    class Key : IKey 
    {	
    	public string ToString(string dummy) 
    	{
    	    return "myspecialKey";
    	}
    }
 

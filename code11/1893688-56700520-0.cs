    public class ObjectFactory
    {
    	public BaseType Instance(string name)
    	{
    		switch(name)
    		{
    			case "A":
    				return A();
    			case "B":
    				return B()
    		}
    	}
    }

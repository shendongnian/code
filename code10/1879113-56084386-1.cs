    public class Example
        {
        	private int _propertyValue;
        	public int SlidingDoors
        	{
        		get
        		{
        			return _propertyValue;
        		}
        
        		set
        		{
        			if (value < 0 || value > 2)
        			{
        				Console.WriteLine("your message here");
        			}else{
        
        			_propertyValue = value;
        }
        		}
        	}
        }

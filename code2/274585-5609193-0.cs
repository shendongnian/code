    public class ClassA : IEquatable<ClassA>
    {
    	public int ID { get; set; }
    
    	public bool Equals(ClassA other)
    	{
    		if (this.ID == other.ID)
    			return true;
    
    		return false;
    	}
    }

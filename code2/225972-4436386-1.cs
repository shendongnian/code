    public class SomeClass : IEquatable<SomeClass>
    {
    	public string Name { get; set; }
    	public double Value { get; set; }
    	public int[] NumberList { get; set; }
    
    	/// <summary>
    	/// Explicitly implemented IEquatable method.
    	/// </summary>
    	public bool IEquatable<SomeClass>.Equals(SomeClass other)
    	{
    		return other.Name == Name &&
    			other.Value == Value &&
    			other.NumberList == NumberList;
    	}
    
    	public override bool Equals(object obj)
    	{
    		var other = obj as SomeClass;
    		if (other == null)
    			return false;
    		return ((IEquatable<SomeClass>)(this)).Equals(other);
    	}
    
    	public override int GetHashCode()
    	{
    		// Determine some consistent way of generating a hash code, such as...
    		return Name.GetHashCode() ^ Value.GetHashCode() ^ NumberList.GetHashCode();
    	}
    }

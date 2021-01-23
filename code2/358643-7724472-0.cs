    class MyClass : ICloneable
    {
    	public object Clone()
    	{
    		var clone = (MyClass)MemberwiseClone();
    		clone.Value = this.Value; // without the way private works, this would not be possible
    		return clone;
    	}
    
    	public int Value{ get; private set;}
    }

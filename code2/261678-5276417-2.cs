    public class A
    {
    	public string TheData1 { get; set; }
    	public string TheData2 { get; set; }
    	public string UniqueID { get; set; }
    }
    
    public class AComparer : IEqualityComparer<A>
    {
    
    	#region IEqualityComparer<A> Members
    
    	public bool Equals(A x, A y)
    	{
    		return x.UniqueID == y.UniqueID;
    	}
    
    	public int GetHashCode(A obj)
    	{
    		return obj.UniqueID.GetHashCode();
    	}
    
    	#endregion
    }

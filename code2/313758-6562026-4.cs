    public class TypeComparerById : IEqualityComparer<Type>
    {
    	public bool Equals(Type t1, Type t2)
    	{
    		if (t1.Id == t2.Id)
    		{
    			return true;
    		}
    		else
    		{
    			return false;
    		}
    	}  
    
    	public int GetHashCode(Type t)
    	{
    		return t.Id.GetHashCode();		
    	}
    }

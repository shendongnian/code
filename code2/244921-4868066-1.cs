    public class Effect
    {
    	public static bool operator == ( Effect a, Effect b )
    	{
    		if (a == null) && (b == null) return true;
                if (a == null) return false;
                return a.Equals ( b );
    	}
    
    	public static bool operator != ( Effect a, Effect b )
    	{
    		return !(a == b);
    	}
    
    	public bool Equals ( Effect effect )
    	{
                if (b == null) return false;
    		return this.TypeID.Equals ( effect.TypeID );
    	}
    
    	public override bool Equals ( object obj )
    	{
                if (obj == null) return false;
    		return this.TypeID.Equals ( ( ( Effect ) obj ).TypeID );
    	}
    }

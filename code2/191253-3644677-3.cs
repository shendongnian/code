    public class ByteArrayEqualityComparer : EqualityComparer<byte[]>
    {
    	public override bool Equals(byte[] x, byte[] y)
    	{
    		return x != null && y != null
    					&& x.Length == 8 && y.Length == 8
    					&& x[0] == y[0]
    					&& x[1] == y[1]
    					&& x[2] == y[2]
    					&& x[3] == y[3]
    					&& x[4] == y[4]
    					&& x[5] == y[5]
    					&& x[6] == y[6]
    					&& x[7] == y[7];
    	}
    
    	public override int GetHashCode(byte[] obj)
    	{
    		return obj.GetHashCode();
    	}
    }

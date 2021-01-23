    public class IntRacional : Racional<int>
    {
    	public static Racional<int> operator +(IntRacional a, IntRacional b)
    	{
    		return new Racional<int>()
    		{
    			Nominator = a.Nominator + b.Nominator,
    			Denominator = a.Denominator + b.Denominator
    		};
    	}
    }

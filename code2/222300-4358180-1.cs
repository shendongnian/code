    public static class MathF
    	{
    		public static Func<double, float> Cos = angleR => (float)System.Math.Cos(angleR);
    		public static Func<double, float> Sin = angleR => (float)System.Math.Sin(angleR);
    	}
    
    	public static class MathF2
    	{
    		public static float Cos(float pValue) {return (float)System.Math.Cos(pValue);}
    	}
    public static class MathExtensions
    	{
    		public static float ToFloat(this double value)
    		{
    			return (float)value;
    		}
    	}

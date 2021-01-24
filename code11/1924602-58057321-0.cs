    using System;
    
    // file curve.txt
    namespace UserFunction
    {                
    	public class BinaryFunction
    	{
    		public static double MyFunction(double x, double param)
    		{
    	 		return param == 0 ?  MyFunction0(x, 0.3) : MyFunction1(x);
    		}
    		              
    		private static double MyFunction0(double x, double param)
    		{
    			return (1 - param) * x + param * (Math.Pow(x, 3));
    		}
    		private static double MyFunction1(double x)
    		{
    			return x * 2;
    		}
    	}
    };

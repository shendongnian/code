    using System;
    using System.Collections.Generic;
    using System.Text;
    namespace test1
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			Int32 myInt = ConvertValue(86389327923.678);
    			Console.WriteLine(myInt);
                        myInt = ConvertValue(-86389327923.678);
    			Console.WriteLine(myInt);
                        myInt = ConvertValue(8.678);
    			Console.WriteLine(myInt);
    			Console.ReadKey();
    		}
    
    		static private Int32 ConvertValue(double value)
    		{
    			if (value > Int32.MaxValue)
    			{
    				Console.WriteLine("Couldn't convert value " + value + " to Int32");
    				return Int32.MaxValue;
    			}
    			else if (value < Int32.MinValue)
    			{
    				Console.WriteLine("Couldn't convert value " + value + " to Int32");
    				return Int32.MinValue;
    			}
    			else
    			{
    				return Convert.ToInt32(value);
    			}
    		}
    	}
    }

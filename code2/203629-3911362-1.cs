    using System;
    
    class Program
    {
    	static void Main(string[] args)
    	{
    		int i = 100;
    		object temp = i;
    		try
    		{
    			short s0 = (short)i;
    			short s1 = (short)(int)temp;
    			short s2 = (short)temp;
    		}
    		catch (Exception ex) { Console.WriteLine(ex); }
        }
    }

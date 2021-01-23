    using System;
    public sealed class Program{
    	
    	public static void Main()
    	{
    		float a = 3f; // presumably the same as float a = new float(3f);
    		float b = a;
    		a = a + 1;
    		Console.WriteLine("A:{0}", a);//prints 4
    		Console.WriteLine("B:{0}", b);//prints 3
    	}
    }

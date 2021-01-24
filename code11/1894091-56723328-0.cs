    using System;
    
    public class Program
    {
    	static void ModifyInt(ref int x)  # ref keyword here
        {
    		x = x * 2;
        }
       
        public static void Main()
        {
    		int value = 22;
    		ModifyInt(ref value);         # ref keyword here
    		
            Console.WriteLine( value );
        }
    }

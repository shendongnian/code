    using System.Collections.Generic;
    using System;
    					
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Hello World");
    
            PulicZoom.Lst.Add(1);
            PulicZoom.Lst.Add(2);
            PulicZoom.Lst.Add(3);
    
            for (int x = 0; x < PulicZoom.Lst.Count; x++)
    
            {
                Console.WriteLine("This is number {0}.", PulicZoom.Lst[x]);
            }
    		
    		Tests test = new Tests();
    		test.Next();
        }
    
        public class Tests
        {
            public void Next()
            {
                Console.WriteLine("Value of Xyz is: {0}", PulicZoom.Xyz);
                Console.WriteLine("{0}", PulicZoom.Lst.Count);
                List<int> Lst2 = new List<int>(PulicZoom.Lst);
                Console.WriteLine("Lst2 has {0} values.", Lst2.Count);
            }
        }
    	
    	public static class PulicZoom
    	{
    		public static int Xyz { get; set; } = 15;
    		public static List<int> Lst = new List<int>();
    	}
    	
    }

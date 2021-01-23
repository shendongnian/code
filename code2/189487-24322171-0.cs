An Example will clear your concept.
    class Program
    {
        static void Main()
        {
    	A.A1();
    	A.A2();
        }
    }
    
    //Contents of file A1.cs: C#
    
    using System;
    
    partial class A
    {
        public static void A1()
        {
    	Console.WriteLine("A1");
        }
    }
    
    //Contents of file A2.cs: C#
    
    using System;
    
    partial class A
    {
        public static void A2()
        {
    	Console.WriteLine("A2");
        }
    }
  
    Output
    
    A1
    A2

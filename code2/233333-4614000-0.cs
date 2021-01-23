    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApplication1
    {
    	class Program
    	{
    		public enum EnumA
    		{
    			One,
    			Two,
    			Three,
    			Four
    		}
    
    		static void Main(string[] args)
    		{
    			HashSet<EnumA> test = new HashSet<EnumA>();
    
    			test.Add(EnumA.Four);
    
    			Console.WriteLine("Contains one:");
    			Console.WriteLine(test.Contains(EnumA.One));
    			Console.WriteLine("Contains four:");
    			Console.WriteLine(test.Contains(EnumA.Four));
    			Console.WriteLine();
    			Console.ReadLine();
    
    			return;
    		}
    	}
    }

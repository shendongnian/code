    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace RedundantCastTest
    {
    	class Program
    	{
    		static object get()
    		{ return "asdf"; }
    
    		static void Main(string[] args)
    		{
    			object obj = get();
    			if ((string)obj == "asdf")
    				Console.WriteLine("Equal: {0}, len: {1}", obj, ((string)obj).Length);
    		}
    	}
    }

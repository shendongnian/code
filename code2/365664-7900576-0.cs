    using System;
    using System.Linq;
    using System.Diagnostics;
    
        public class Program
        {	
        	[STAThread]
        	static void Main(string[] args)
        	{
        		Test43545();
        		Test1();
        		Console.ReadLine();
        	}
        	
        	public static void Test43545(){
        		Test1();
        	}
        	public static void Test1()
        	{
        		StackTrace stackTrace = new StackTrace();    
          		StackFrame[] stackFrames = stackTrace.GetFrames();
        
        	  	// write call stack method names
        	  	foreach (StackFrame stackFrame in stackFrames)
        	  	{
        	    	Console.WriteLine(stackFrame.GetMethod().Name);
        	  	}
        	}
        }

    using System;
    using Mono.CSharp;
    
    namespace REPLtest
    {
    	class MainClass
    	{
    		public static void Main (string[] args)
    		{
    			var r = new Report (new ConsoleReportPrinter ());
    			var cmd = new CommandLineParser (r);
    
    			var settings = cmd.ParseArguments (args);
    			if (settings == null || r.Errors > 0)
    				Environment.Exit (1);
    
    			var evaluator = new Evaluator (settings, r);
    
    			evaluator.Run("using System;");
    
    			//evaluator.Run("print (1+2);");
    			int sum = (int) evaluator.Evaluate("1+2;");
    
    			Console.WriteLine ("The sum of 1 + 2 is {0}", sum);
    		}
    	}
    }

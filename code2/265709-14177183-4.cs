        // Call R from .NET. Advantage is that everything is in process.
        // Tested on VS2012, will probably work on VS2010.
		using System;
		using System.IO;
		using System.Linq;
		using RDotNet;
		
		class Program
		{
		    static void Main(string[] args)
		    {
		        // Set the folder in which R.dll locates.
		        var envPath = Environment.GetEnvironmentVariable("PATH");
		        var rBinPath = @"C:\Program Files (x86)\R\R-2.11.1\bin";
		        //var rBinPath = @"C:\Program Files\R\R-2.11.1-x64\bin"; // Doesn't work ("DLL was not found.")
		        Environment.SetEnvironmentVariable("PATH", envPath + Path.PathSeparator + rBinPath);
		        using (REngine engine = REngine.CreateInstance("RDotNet"))
		        {
		            // Initializes settings.
		            engine.Initialize();
		
		            // .NET Framework array to R vector.
		            NumericVector group1 = engine.CreateNumericVector(new double[] { 30.02, 29.99, 30.11, 29.97, 30.01, 29.99 });
		            engine.SetSymbol("group1", group1);
		            // Direct parsing from R script.
		            NumericVector group2 = engine.Evaluate("group2 <- c(29.89, 29.93, 29.72, 29.98, 30.02, 29.98)").AsNumeric();
		
		            // Test difference of mean and get the P-value.
		            GenericVector testResult = engine.Evaluate("t.test(group1, group2)").AsList();
		            double p = testResult["p.value"].AsNumeric().First();
		
		            Console.WriteLine("Group1: [{0}]", string.Join(", ", group1));
		            Console.WriteLine("Group2: [{0}]", string.Join(", ", group2));
		            Console.WriteLine("P-value = {0:0.000}", p);
		        }
		    }
		}

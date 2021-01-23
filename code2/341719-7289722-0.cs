    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace TestThat
    {
        class MainClass
        {
            public static void Main (string[] args)
            {
    			var theList = new [] {
    				new { PartNumber="FID34" }
    			};
    			
    			var result = theList
			        .Where (line => line.PartNumber.StartsWith("FID", StringComparison.CurrentCultureIgnoreCase)
    				.OrderBy (line =>
    				{	
    					int pnumber;
    					return Int32.TryParse(line.PartNumber.Substring(3), out pnumber)
                             ? pnumber 
                             : 0;
    				});
    
            }
        }
    }

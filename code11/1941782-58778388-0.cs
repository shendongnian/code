    using System;
    using System.Collections.Generic;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var ihm = new 
        {
            InvoiceLineModels = new List<Object>
            {
               new {
    			   Test = 1,
                   //ihm = ihm Can't be used here until the declaration is completed nor can this be used.
    		   }
            }
        };
    		//ihm is available here 
    		Console.WriteLine(ihm.ToString());
    	}
    }

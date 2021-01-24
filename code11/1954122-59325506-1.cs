    using System;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var option = 1;
    		var list = new[]{ new Rental{ RentalID = 1,  Quote = 1 }, new Rental{ RentalID = 2,  Quote = 2 }, new Rental{ RentalID = 3,  Quote = 3 }, new Rental{ RentalID = 4,  Quote = 1 }, new Rental{ RentalID = 5,  Quote = 3 } };
    		
    		var minQuote = list.Min((p => p.Quote));		
    		var maxQuote = list.Max((p => p.Quote));
    	    var result = list.Where(p => (option == 1 && p.Quote == minQuote) || (option == 2 && p.Quote == maxQuote));
    		if(option == 0)
    			result = list; 
    		
    		foreach(var item in result)
    				Console.WriteLine(item.Quote);
    	}
    	
    	
    	public class Rental
        {
            public int RentalID { get; set; }
    
            public decimal Price { get; set; }
    		
    		public decimal Quote { get; set; }
    	}
    }

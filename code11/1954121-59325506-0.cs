    using System;
    using System.Linq;
					
    public class Program
    {
    	public static void Main()
    	{
    		var option = 0;
    		var list = new[]{ new Rental{ RentalID = 1,  Quote = 1 }, new Rental{ RentalID = 2,  Quote = 2 }, new Rental{ RentalID = 3,  Quote = 3 } };
    		
    		var minQuote = list.Min((p => p.Quote));		
    		var maxQuote = list.Max((p => p.Quote));
    	    var result = list.FirstOrDefault(p => (option == 1 && p.Quote == minQuote) || (option == 2 && p.Quote == maxQuote));
    		if(option == 0)
    			foreach(var item in list)
    				Console.WriteLine(item.Quote);
    		else{
    			Console.WriteLine(result.Quote);
    		}
    	}
    	
    	
    	public class Rental
        {
            public int RentalID { get; set; }
    
            public decimal Price { get; set; }
    		
    		public decimal Quote { get; set; }
    	}
    }

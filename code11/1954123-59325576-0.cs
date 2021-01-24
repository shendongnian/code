    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Program {
    	public class Rental
    	{
    		public int RentalID { get; set; }
    		public decimal Price { get; set; }
    		public int Duration { get; set; }
    		public decimal Quote { get; set; }
    	}
    
    	public static void Main()
    	{
    		// sample data
    		var rentals = new List<Rental> {
    			new Rental { RentalID = 1, Price = 100.00m, Duration = 2, Quote = 200.00m },
    			new Rental { RentalID = 2, Price = 100.00m, Duration = 2, Quote = 200.00m },
    			new Rental { RentalID = 3, Price = 100.00m, Duration = 1, Quote = 100.00m },
    			new Rental { RentalID = 4, Price = 100.00m, Duration = 1, Quote = 100.00m },
    			new Rental { RentalID = 5, Price = 100.00m, Duration = 5, Quote = 500.00m }
    		};
    
    		// get min quote
    		var minQuote = (from s in rentals select s.Quote).Min();
    
    		// get max quote
    		var maxQuote = (from s in rentals select s.Quote).Max();
    
    		Console.WriteLine(string.Format("min={0} max={1}", minQuote, maxQuote));
    
    		// Outputs: min=100.00 max=500.00
    	}
    }

    class Program {
    	public class Quote {
    		public string HaulierName { get; set; }
    		public string FulfillmentCenter { get; set; }
    		public int PalletQty { get; set; }
    		public double Price { get; set; }
    
    		public override string ToString() {
    			return $"{HaulierName} {FulfillmentCenter} {PalletQty} {Price}";
    		}
    	}
    	static void Main(string[] args) {
    		{
    			var Quotes = new List<Quote>();
    			Quotes.Add(new Quote() {
    				HaulierName = "Hellmans",
    				FulfillmentCenter = "BHX4",
    				PalletQty = 2,
    				Price = 122
    
    			});
    
    			Quotes.Add(new Quote() {
    				HaulierName = "Pallet Online",
    				FulfillmentCenter = "BHX4",
    				PalletQty = 2,
    				Price = 111.98
    			});
    
    			foreach (var item in Quotes) {
    				Console.WriteLine(item);
    			}
    
    			Console.ReadLine();
    		}
    	}
    }

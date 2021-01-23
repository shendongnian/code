    namespace ConsoleApplication1 {
    	class Program {
    		static void Main(string[] args) {
    			Console.WriteLine(GetLastBilled(new DateTime(2008, 4, 26), 6));
    			Console.WriteLine(GetNextBilled(new DateTime(2008, 4, 26), 6));
    
    			Console.WriteLine(GetLastBilled(new DateTime(2008, 4, 26), 4));
    			Console.WriteLine(GetNextBilled(new DateTime(2008, 4, 26), 4));
    
    			Console.WriteLine(GetLastBilled(new DateTime(2008, 4, 26), 2));
    			Console.WriteLine(GetNextBilled(new DateTime(2008, 4, 26), 2));
    
    			Console.WriteLine("Complete...");
    			Console.ReadKey(true);
    		}
    
    		static DateTime GetLastBilled(DateTime initialDate, int billingInterval) {
    			// strip time and handle staggered month-end and 2/29
    			var result = initialDate.Date.AddYears(DateTime.Now.Year - initialDate.Year);
    			while (result > DateTime.Now.Date) {
    				result = result.AddMonths(billingInterval * -1);
    			}
    			return result;
    		}
    
    		static DateTime GetNextBilled(DateTime initialDate, int billingInterval) {
    			// strip time and handle staggered month-end and 2/29
    			var result = initialDate.Date.AddYears(DateTime.Now.Year - initialDate.Year);
    			while (result > DateTime.Now.Date) {
    				result = result.AddMonths(billingInterval * -1);
    			}
    			result = result.AddMonths(billingInterval);
    			return result;
    		}
    	}
    }

    public class ListDemo
    {
    	public static void Main(string[] args) 
    	{
    		//Try erasing some elements of this list, leave one element alone
    		List<string> AccountNumbers = new List<string>(){ "CC13563", "CC13578", "CC13525", "CC13585", "CC13500" };
    		
    		var account = AccountNumbers.Skip(1).Any() ? null : AccountNumbers.SingleOrDefault();
    		
    		//If Account is null it won't display anything...
    		Console.Write("The element of your list: " + account + "\n");	
    	}
    }

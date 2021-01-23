    	class Program
    	{
    		static void Main(string[] args)
    		{
    			Console.Write("input: ");
    			string line = Console.ReadLine();
    
    			int n;
    			if (!int.TryParse(line, out n))
    			{
    				Console.WriteLine("Enter a valid integer number.");
    				return;
    			}
    
    			for (int i = 0; i < n; i++)
    			{
    				int l = Math.Abs(n - i * 2 - 1) + 1;
    				if (n % 2 != 0) l = n - l + 1;
    				
                    Console.Write(Enumerable.Repeat(" ", n - l).DefaultIfEmpty("").Aggregate((a, b) => a + b));
    				Console.WriteLine(Enumerable.Repeat("* ", l).DefaultIfEmpty("").Aggregate((a, b) => a + b));
    			}
    		}
    	}

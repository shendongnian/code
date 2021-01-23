    static void Main(string[] args)
		{
			Console.WriteLine("Please enter your integer (0 to stop): ");
			
			int a = int.Parse(Console.ReadLine());
			while(a>0)
			{
				List<int> primeFactors = PrimeFactors(a);
				LogFactorList(primeFactors);
				a = int.Parse(Console.ReadLine());
			}
			Console.WriteLine("Goodbye.");
		}
		
		/// <summary>
		/// Find prime factors
		/// </summary>
		public static List<int> PrimeFactors(int a)
		{
			List<int> retval = new List<int>();
			for (int b = 2; a > 1; b++)
			{				
				while (a % b == 0)
				{
					a /= b;
					retval.Add(b);
				}				
			}
			return retval;
		}
		/// <summary>
		/// Output factor list to console
		/// </summary>
		private static void LogFactorList(List<int> factors)
		{
			if (factors.Count == 1)
			{
				Console.WriteLine("{0} is Prime", factors[0]);
			}
			else
			{
				StringBuilder sb = new StringBuilder();
				for (int i = 0; i < factors.Count; ++i)
				{
					if (i > 0)
					{
						sb.Append('*');
					}
					sb.AppendFormat("{0}", factors[i]);
				}
				Console.WriteLine(sb.ToString());
			}
		}

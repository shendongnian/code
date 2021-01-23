	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	 
	namespace sieve
	{
		class Program
		{
			static void Main(string[] args)
			{
				int maxprime = int.Parse(args[0]);
				ArrayList primelist = sieve(maxprime);
	 
				foreach (int prime in primelist)
					Console.WriteLine(prime);
	 
				Console.WriteLine("Count = " + primelist.Count);
				Console.ReadLine();
			}
	 
			static ArrayList sieve(int arg_max_prime)
			{
				BitArray al = new BitArray(arg_max_prime, true);
	 
				int lastprime = 1;
				int lastprimeSquare = 1;
	 
				while (lastprimeSquare <= arg_max_prime)
				{
					lastprime++;
	 
					while (!(bool)al[lastprime])
						lastprime++;
	 
					lastprimeSquare = lastprime * lastprime;
	 
					for (int i = lastprimeSquare; i < arg_max_prime; i += lastprime)
						if (i > 0)
							al[i] = false;
				}
	 
				ArrayList sieve_2_return = new ArrayList();
	 
				for (int i = 2; i < arg_max_prime; i++)
					if (al[i])
						sieve_2_return.Add(i);
	 
				return sieve_2_return;
			}
		}
	}

asp
public static void Main(string[] args)
{
	// The number to find its smallest multiple
	var n = 20;
	// A list that contains all primes that are founded across the calculation
	var calculatedPrimes = new List<int>();
	// Start through the numbers that x (the output number) should be divisible by
	for (var i = 2; i <= n; i++)
	{
		// Get primes of i
		var primes = GetPrimeFactors(i);
		// Loop through primes of i and add to "calculatedPrimes" the ones that are not 
		// in "calculatedPrimes"
		primes.ForEach(prime =>
		{
			if (!calculatedPrimes.Contains(prime) ||
				calculatedPrimes.Count(p => p == prime) < primes.Count(p => p == prime))
			{
				calculatedPrimes.Add(prime);
			}
		});
	}
	// The output number should be the multiple of all primes in "calculatedPrimes" list
	var x = calculatedPrimes.Aggregate(1, (res, p) => res * p);
	Console.WriteLine(x);
	Console.ReadLine();
}
// A function to get prime factors of a given number n
// (example: if n = 12 then this will return [2, 2, 3])
private static List<int> GetPrimeFactors(int n)
{
	var res = new List<int>();
	while (n % 2 == 0)
	{
		res.Add(2);
		n /= 2;
	}
	for (var i = 3; i <= Math.Sqrt(n); i += 2)
	{ 
		while (n % i == 0)
		{
			res.Add(i);
			n /= i;
		}
	}
	if (n > 2)
		res.Add(n);
	return res;
}

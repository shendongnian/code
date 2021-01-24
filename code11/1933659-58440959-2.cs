public static void Main()
{
	for(uint i = 0; i < 1000; i++) {
		if (IsPrime(i)) Console.Write($"{i},");
	}
}
private static bool IsPrime(uint n)
{
   if (n < 3) return false;
   for (uint i = 2; i < n; i++)
       if (n % i == 0) return false;
   return true;
}
If you want to go a bit faster, let's ask Wikipedia for help.
/// <summary>
/// Tests the number for primality. It is a c# version of the pseudocode from 
/// https://en.wikipedia.org/wiki/Primality_test
/// </summary>
private static bool IsPrime2(uint n)
{
	// The following is a simple primality test in pseudocode using 
	// the simple 6k ± 1 optimization mentioned earlier. 
	// More sophisticated methods described below are much faster for large n. 
	if (n <= 3)
		return n > 1;
	if (n % 2 == 0 || n % 3 == 0)
		return false;
	uint i = 5;
	while (i * i <= n)
	{
		if (n % i == 0 || n % (i + 2) == 0)
			return false;
		i = i + 6;
	}
	return true;
}

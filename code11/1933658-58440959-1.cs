public static void Main()
{
	for(uint i = 0; i < 1000; i++) {
		if (IsPrime(i)) Console.Write($"{i},");
	}
}
/// <summary>
/// Tests the number for primality. It is a c# version of the pseudocode from 
/// https://en.wikipedia.org/wiki/Primality_test
/// </summary>
/// <param name="n"></param>
/// <returns></returns>
private static bool IsPrime(uint n)
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
----
# Note 
For types that can contain biiig numbers you can refer to [Integral numeric types (C# reference)](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/integral-numeric-types)
int     -2,147,483,648 to 2,147,483,647	
uint	0 to 4,294,967,295
ulong	0 to 18,446,744,073,709,551,615

public class Program
{
	public static void Main()
	{
		var tests = new[]{6, -15, 0};
		
		foreach (var test in tests)
		{
			Console.WriteLine(ShowSequence(test));
		}
	}
	public static string ShowSequence(int n)
	{
		if (n == 0)
		{
			return n + " = 0";
		}
		if (n < 0)
		{
			return n + " < 0";
		}
		// generate all numbers from 0 to n. 
		var enumeration = Enumerable.Range(0, n+1);
		
		var plusOperatorConcatenation = String.Join(" + ",  enumeration ) ;
		
		return plusOperatorConcatenation + " = " + enumeration.Sum();
	}
}
Live Demo: https://dotnetfiddle.net/Iu0vyf

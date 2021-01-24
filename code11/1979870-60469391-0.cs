c#
namespace Utils 
{
	// using static
	using static Utils.Helper;
	public class Program
	{
		public static void Main()
		{
			// no need to type Helper.Pow(2, 2);
			var x = Pow(2, 2);
			Console.WriteLine(x);
		}
	}
}
namespace Utils
{
	public static class Helper
	{
		public static double Pow(int x, int pow) => Math.Pow(x, pow);
	}
}

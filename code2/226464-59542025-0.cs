public class Program
{
	public static void Main()
	{
		IList<int> intList = new List<int>() { 10, 21, 91, 30, 91, 45, 51, 87, 87 };
		var largest = intList.Max();
		
		Console.WriteLine("Largest Element: {0}", largest);
		
		var secondLargest = intList.Max(i => {
			if(i != largest)
				return i;
			return 0;
		});
		
		Console.WriteLine("second highest element in list: {0}", secondLargest);
	}
}

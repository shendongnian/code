	public static void Main()
	{
		var arr = new double[]{-88.98559, -94.98711, -95.79591, -98.04622, 100.0001, -101.57691, -110.00614};
		var arrList = new List<double>(){};
		
		foreach (var value in arr)
		{
			arrList.Add(value);
		}
		Console.WriteLine(arrList.Min().ToString());
		Console.WriteLine(arrList.Max().ToString());
	}

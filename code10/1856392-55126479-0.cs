    public static void Main()
	{
		var myStringValue = "burger 5$";
		
		var numbersArray = myStringValue.ToArray().Where(x => char.IsDigit(x));
		
		foreach (var number in numbersArray)
		{
			Console.WriteLine(numbersArray);
		}
	}

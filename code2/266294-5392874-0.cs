    static void Main(string[] args)
	{
		var thisstring = "The {0} car is {1}";
		var FirstPossiblilty = new string[] { "Small", "Big" };
		var SecondPosibility = new string[] { "Red", "Blue" };
		foreach (string tempFirst in FirstPossiblilty)
		{
			foreach (string tempSecond in SecondPosibility)
			{
				Console.WriteLine(string.Format(thisstring, tempFirst, tempSecond));
			}
		}		
		Console.Read();
	}

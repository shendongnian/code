	string input = "";
	int numCheck = 0;
	Regex whiteList = new Regex("^[1234567890]+$");
	do
	{
		numCheck = 0;
		Console.Write("Please input the two numbers you wish to use seperated by a space: ");
		input = Console.ReadLine();
		var numbers = input.Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
		if (numbers.Length != 2 || !numbers.All(num => whiteList.IsMatch(num)))
		{
			Console.WriteLine("You entered " + input + " You did not enter two numbers seperated by a space, please try again.");
			numCheck = 1;
		}
	}
	while (numCheck == 1);

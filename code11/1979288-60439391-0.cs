	public static void Main()
	{
		bool exit = false;
		do {
			exit = ProcessInput();
		}
		while(!exit);
	}
	private static bool ProcessInput()
	{
		string nameCapInput = Console.ReadLine();
		
		bool containsInt = nameCapInput.Any(char.IsDigit);
    	bool isMadeOfLettersOnly = nameCapInput.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
		
		if (nameCapInput.Equals("exit", StringComparison.CurrentCultureIgnoreCase))
		{
			return true; //exiting so return true
		}
		else if (containsInt)
		{
			Console.WriteLine("You can't capitalize numbers. Use letters only. Try again.");
		}
		else if (isMadeOfLettersOnly)
		{
			string upper = nameCapInput.ToUpper();
			Console.WriteLine("The uppercase version of your entered text is: {0}", upper);
		}	
		return false; //no exit, so return false
	}

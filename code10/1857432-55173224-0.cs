	public static double GetUserInput()
	{
		string numbersEntered = "";
		ConsoleKeyInfo lastKey;
		
        // read keys until Enter is pressed
		while ((lastKey = Console.ReadKey()).Key != ConsoleKey.Enter)
		{
            // if Escape is pressed, exit
			if (lastKey.Key == ConsoleKey.Escape)
			{
				return -1;
			}
			
            // otherwise, add the key entered to the input
			numbersEntered += lastKey.KeyChar.ToString();
		}
		
        // and convert the final number to double
		return Convert.ToDouble(numbersEntered);
	}

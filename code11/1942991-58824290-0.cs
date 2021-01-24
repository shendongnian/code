	int xCoordinate = 0;
	int failAttemptsCounter = 0;
    // this means: WHILE the Conversion result is FALSE go inside the brackets and repeat the step
	while (Int32.TryParse(Console.ReadLine(), out xCoordinate) == false)
	{
		failAttemptsCounter++;
		Console.WriteLine("Invalid Input, please only integers");
		if (failAttemptsCounter > 10)
		{
			Console.WriteLine("Stop kidding around google what an integer is !");
		}
	}
	
	// you end up here only when the conversion has worked
	Console.WriteLine(xCoordinate);

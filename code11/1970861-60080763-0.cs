	private static void QuestionTimer_Elapsed(object sender, ElapsedEventArgs e)
	{
		secondCounter = secondCounter + 1;
		Console.SetCursorPosition(0, 2); //This is a row number...
		Console.Write("\rSeconds Remaining: {0}: ", 30 - secondCounter);
		if (secondCounter >= 30)
		{
			Console.WriteLine("Time's up!");
			questionTimer.Stop();
		}
	}

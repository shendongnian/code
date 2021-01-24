	for (int i = 0; i <= number.Length - 1; i++)
	{
		Console.Write("Number {0}: ", i);
		bool Parse = Int32.TryParse(Console.ReadLine(), out outValue);
		if (Parse)
		{
			// if parsing is successfull, then add to array and to sum :)
			number[i] = outValue;
			newSum += number[i];
		}
		else
		{
			Console.WriteLine("You Have Entered InValid Format: ");
			// just decrement iterator to repeat this iteration
			i--;
		}
	}

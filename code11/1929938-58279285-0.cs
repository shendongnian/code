	while (counter < 10)
	{
		string line = Console.ReadLine();
		bool success = int.TryParse(line, out number);
		if (success == true)
		{
			total[counter] = number;
			counter++;
		}
		else if (line == "quit")
		{
			break;
		}
		else
		{
			Console.WriteLine("Wrong input.");
		}
	}

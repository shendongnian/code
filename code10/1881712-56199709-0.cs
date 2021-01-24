	var rnd1 = new Random();
	var rollsRemaining = 6;
	var sum = 0;
	while (rollsRemaining > 0)
	{
		int dice1 = rnd1.Next(1, 7);
        Console.WriteLine("You have rolled " + dice1);
		if (dice1 == 6)
		{
			rollsRemaining += 2;	
		}
		else
		{
			sum += dice1;
			rollsRemaining -= 1;
		}
	}
	Console.WriteLine("The sum is " + sum);

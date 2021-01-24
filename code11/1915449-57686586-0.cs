	public void Check()
	{
		// 4 seconds
		Timer TimerOne = new Timer(4 * 1000);
		var expired = false;
		void TimerTick(Object obj, ElapsedEventArgs e)
		{
			Console.WriteLine("Max time reached");
			TimerOne.Stop();
			expired = true;
		}
		TimerOne.Elapsed += TimerTick;
		TimerOne.Start();
		// This for loop will go as long all items inside the list are entered
		for (int i = 0; i < 99; i++)
		{
			if (expired)
			{
				break;
			}
			if (ListOne.Test.Contains(UserInput()))
			{
				Console.WriteLine("Correct!");
				points++;
				if (points == ListOne.Test.Capacity)
					break;
				else
					continue;
			}
			else
				Console.WriteLine("Wrong!");
		}
		TimerOne.Stop();
		Console.WriteLine("Stopped\n");
	}

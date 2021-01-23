		DateTime timeA = DateTime.Now;
		DateTime timeB = DateTime.Now.AddHours(-10.0);
		
		if ( (double)timeA.TimeOfDay.Ticks / (double)timeB.TimeOfDay.Ticks > 2.0f )
			Console.WriteLine("Time A is more than twice time B");
		else
			Console.WriteLine("Time A is NOT more than twice time B");

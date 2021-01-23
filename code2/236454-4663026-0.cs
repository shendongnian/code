		DateTime timeA = DateTime.Now;
		DateTime timeB = DateTime.Now.AddHours(-10.0);
		
		if ( timeA.TimeOfDay.Ticks / timeB.TimeOfDay.Ticks > 2.0f )
			Console.WriteLine("Time A is more than twice time B");
		else
			Console.WriteLine("Time A is NOT more than twice time B");

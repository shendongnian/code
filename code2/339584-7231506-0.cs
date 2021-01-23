	using System;
	using System.Collections.Generic;
	
	public class MyClass
	{
		public static void Main()
		{
			// client code with semi-arbitrary DateTime suuplied
			List<DateTime> week = GetWeek(DateTime.Today.AddDays(-2));
			foreach (DateTime dt in week) Console.WriteLine(dt);
		}
		
		public static List<DateTime> GetWeek(DateTime initDt)
		{
			// walk back from supplied date until we get Monday and make 
			// that the initial day
			while (initDt.DayOfWeek != DayOfWeek.Monday) 
				initDt = initDt.AddDays(-1.0);
			
			List<DateTime> week = new List<DateTime>();
			
			// now enter the initial day into the collection and increment
			// and repeat seven total times to get the full week
			for (int i=0; i<7; i++)
			{ 
				week.Add(initDt);
				initDt = initDt.AddDays(1.0);
			}
			
			return week;
		}
	}

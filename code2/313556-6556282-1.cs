    DateTime startTime = DateTime.Now;
    DateTime endTime = DateTime.Now.AddDays(381);
    TimeSpan span = endTime.Subtract(startTime);
       
    Console.WriteLine("Time Difference (months): " + Math.Round((decimal)span.Days/30,2));

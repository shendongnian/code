    static void Main(string[] args)
    {
    	string hours = @"
    	01:30
    	00:45
    	00:05
    	02:00";
    
    	TimeSpan totalHoursSpan = hours.Split(new [] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
    		 .Select(x => DateTime.ParseExact(x.Trim(), "HH:mm", CultureInfo.InvariantCulture).TimeOfDay)
    		 .Aggregate(TimeSpan.Zero, (total, span) => total += span);
    
    
    	string totalHrs = string.Format("{0:00}:{1:00}", (int)totalHoursSpan.TotalHours, totalHoursSpan.Minutes);
        Console.WriteLine(totalHrs);
    }

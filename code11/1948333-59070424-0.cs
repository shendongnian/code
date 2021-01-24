    public void SkippedDailyTask()
    {
        var pendingtasks = GetPendingTasks();
        if (pendingtasks.Count() == 0)
        {
            Console.WriteLine("Empty List");
        }
        else
        {
            foreach (var item in pendingtasks)
            {
    			var hourNow = Convert.ToInt32(DateTime.Now.ToString("HH"));
    			// var hourItem = item.EndTime.Hour;
    			var hourItem = Convert.ToInt32(item.EndTime.ToString("HH"));
                if (hourItem <= hourNow)
                {
                    if (item.EndTime.Minute <= DateTime.Now.Minute)
                    {
                        item.StatusReturner = StatusReturner.Skipped;
                    }
                    else
                    {
                        Console.WriteLine("Empty List");
                    }
                    context.SaveChanges();
                }
    
            }
    
        }
    }

    List<DateTime> dates = ...
    
    Dictionary<int, IList<DateTime>> groupedDates 
    	= new Dictionary<int, IList<DateTime>>();
    	
    foreach (DateTime date in dates)
    {
         int quarter = (date.Month / 3) + 1;
         if (groupedDates.ContainsKey(quarter)) 
         {
             groupedDates[quarter].Add(date);
         }
         else  
         {
             List<DateTime> dateGroup = new List<DateTime>();
             dateGroup.Add(date);
             groupedDates.Add(quarter, dateGroup);
         }
    }

    var weekIndexTuple = Season.Weeks
                               .OrderBy(w => w.WeekStarts)
                               .Select((week, index) => 
                                        new { Week = week, Index = index })
                               .FirstOrDefault(a => a.Week.Id == Id);
    if(weekIndexTuple != null)
    {
        return weekIndexTuple.Index;
    }
    else
    {
       // I'm not sure how you want to continue in this case.
       ...      
    }
  
 

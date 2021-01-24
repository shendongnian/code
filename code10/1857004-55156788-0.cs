    var startDate = DateTime.Today; //today
    
    int currentDayOfWeek = (int)startDate.DayOfWeek; //today
    
    //saturday of this week, disregarding if today is 
    //saturday or sunday, it is up to you to enhance this.
    DateTime thisSaturday = startDate.AddDays(6 - currentDayOfWeek); 
    
    var sessions = 8;
    
    for (int i = 0; i<sessions; i++)
    {
        SaveToDb(thisSaturday);
        thisSaturday = thisSaturday.AddDays(7);  //next week's weekend       
    }
    
    private void SaveToDb(DateTime saturday)
    {
        DateTime sunday = saturday.AddDays(1);
        //insert data for saturday and sunday
    }

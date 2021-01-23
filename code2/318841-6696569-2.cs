    //I leave you the exercise of actually getting the entered dates in DateTime format
    List<DateTime> enteredDates = GetEnteredDatesAsDateTimes();
    var unenteredDates = new List<DateTime>();
    
    //I assume you want days for the current month; 
    //if not you can set up a DateTime using a specified month/year
    var today = DateTime.Today;
    var dateToCheck = new DateTime(today.Year, today.Month, 1);
    
    //You could also make sure the date is less than the current date,
    //or less than a specified "end date".
    while (dateToCheck.Month == today.Month)
    {
       //uses Linq, which requires .NET 3.5
       if(!enteredDates.Any(d=>d.Date == dateToCheck.Date))
          unenteredDates.Add(dateToCheck);
       //use the below code instead for .NET 2.0
       //bool inList = false;
       //foreach(var date in enteredDates)
       //   if(enteredDate.Date == date.Date)
       //   {
       //      inList = true;
       //      break;
       //   }
       //if(!inList) unenteredDates.Add(dateToCheck);
    
       dateToCheck = dateToCheck.AddDays(1);
    }
    
    //unenteredDates now has all the dates for which the user didn't fill out the form.

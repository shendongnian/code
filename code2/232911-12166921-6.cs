    [Test]
    public void GetCountOfWeeks() {
       var startDate = new DateTime(2012, 12, 1); // 4 weeks here
       var endDate = new DateTime(2014, 1, 10); // 52 in 2013 and 2 weeks in 2014
       int numberOfWeeksInRange = 0;
       var cal = new GregorianCalendar();
       for (int year = startDate.Year; year <= endDate.Year; year++)
       {
           int startWeekNumber = 0;
           int endWeekNumber= 0;
           if(year == startDate.Year) { // start date through the end of the year
               startWeekNumber = cal.GetWeekOfYear(startDate, 
                   CalendarWeekRule.FirstDay, DayOfWeek.Thursday);
               endWeekNumber = cal.GetWeekOfYear((
                                      new DateTime(year + 1, 1, 1).AddDays(-1)),
                   CalendarWeekRule.FirstDay, DayOfWeek.Thursday);                       
           } else if(year == endDate.Year) { // start of the given year through the end date
               startWeekNumber = cal.GetWeekOfYear((new DateTime(year, 1, 1)),
                   CalendarWeekRule.FirstDay, DayOfWeek.Thursday);                       
               endWeekNumber = cal.GetWeekOfYear(endDate, 
                   CalendarWeekRule.FirstDay, DayOfWeek.Thursday);                   
           } else { // calculate the number of weeks in a full year                  
               startWeekNumber = cal.GetWeekOfYear(new DateTime(year, 1, 1),
                   CalendarWeekRule.FirstDay, DayOfWeek.Thursday);
               endWeekNumber = cal.GetWeekOfYear((
                                       new DateTime(year + 1, 1, 1).AddDays(-1)),
                   CalendarWeekRule.FirstDay, DayOfWeek.Thursday);                       
           }
           
           numberOfWeeksInRange += endWeekNumber - startWeekNumber;
       }
        numberOfWeeksInRange.Should().Be(58);
    } 

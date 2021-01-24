    var resultList = await  _dbContext.TimeSheetElements
       .Where(t => t.UserId == userId && t.Date.Month == month && t.Date.Year == year)
       .GroupBy(t => t.Date).ToList();
    var chartViewModel = resultList.Select(pc => 
         new ShowPointingChartViewModel
         {
             Day = pc.First().Date.DayOfWeek.ToString(),
             Date = pc.First().Date.ToString(),
             NormalHours = pc.Where(p => p.IsGuard == false && !taskType.Contains(p.UserTask.Type)).Sum(p => p.Duration),
             OutOfBuisnessHours = pc.Where(p => p.IsGuard == true).Sum(p => p.Duration),
             Holidays = pc.Where(p => p.UserTask.Type == "Holiday").Sum(p => p.Duration),
             PublicHolidays = pc.Where(p => p.UserTask.Type == "Public holiday").Sum(p => p.Duration),
             Illness = pc.Where(p => p.UserTask.Type == "Illness").Sum(p => p.Duration),
             GuardFees = pc.Count(p => p.UserTask.Type == "Night Fees"),
             Total = pc.Where(p=>p.UserTask.Type != "Night Fees").Sum(p => p.Duration)
          })
    .ToList();

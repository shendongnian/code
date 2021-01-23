    public static IQueryable GetUnapprovedTimesheets(string period)
    {
       DataContext data = new DataContext();
    
       var times = data
                       .Where(a => a.Period == period && a.Status == 1)
                       .OrderBy(a => a.Employee.LName)
                       .GroupBy(a => a.EmployeeID)
                       .Select(
                          a => new{
                                   System_Time = a.FirstOrDefault(),
                                   TotalReg = data.Times
                                               .Where(b => b.EmployeeID == a.Key 
                                                        && b.Period == period
                                                        && b.PayCode == "211")
                                               .Sum(b => b.Hours)
                                  }
                              );
    
       return times;
    }

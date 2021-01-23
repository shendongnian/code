    Timesheet temp = context.Timesheets
                        .Include("TimesheetEntries")
                        .Where(t => t.Id == timesheet.Id).First();
    context.ApplyCurrentValues<Timesheet>(temp.EntityKey.EntitySetName, timesheet);
    foreach(var tse in timesheet.TimesheetEntries)
    {
        temp.TimesheetEntries.Add(tse); // or update, if need be.
    }
    context.SaveChanges();

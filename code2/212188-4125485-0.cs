    Timesheet DBTimesheet = context.Timesheets
                        .Include("TimesheetEntries")
                        .Where(t => t.Id == timesheet.Id).First();
    //Delete if in database but not in submission
    DBTimesheet.TimesheetEntries
       .Where(dbE => !timesheet.TimesheetEntries.Any(e => e.Id == dbE.Id)).ToList()
       .ForEach(dbE => context.TimesheetEntries.DeleteObject(dbE));
    
    //Update if in submission and in database
    timesheet.TimesheetEntries
        .Where(e => DBTimesheet.TimesheetEntries.Any(dbE => dbE.Id == e.Id)).ToList()
        .ForEach(e => context.TimesheetEntries.ApplyCurrentValues(e));
                        
    //Add if in submission but not in database
    timesheet.TimesheetEntries
        .Where(e => !DBTimesheet.TimesheetEntries.Any(dbE => dbE.Id == e.Id)).ToList()
        .ForEach(e => DBTimesheet.TimesheetEntries.Add(e));
    context.SaveChanges();

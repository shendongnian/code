    var query = (from res in 
                     (from c in session.db.TimesheetAttributes           
                     where ((c.Active == true)           
                            && (c.Timesheet.Active == true)           
                            && (c.ValidFrom <= validDate)           
                            && (c.ValidTo > validDate)           
                            && (c.Timesheet.ContactPersonId == session.ContactPersonAttributes.ContactPersonId))           
                     select new           
                     {   
                         c = c,
                         cr = c.TimesheetRows
                     })
                 select new
                 {
                     Id = c.TimesheetId,           
                     c.Date,           
                     WeekDay = c.Date.ToString("dddd", new CultureInfo("pl-PL")),           
                     Description = String.Format("{0:dd/MM/yyyy}", c.Date),           
                     Hours = String.Format("{0:HH:mm}", (new DateTime((cr.Aggregate(TimeSpan.Zero, (subtotal, t) => subtotal + (t.DateTo - t.DateFrom)).Ticks)))),           
                     c.SickNote,           
                     c.Vacation,           
                     c.OccasionVacation           
                  }).OrderBy(c => c.Date).ToList();  

    const byte statusAttended = 2;
    const byte statusRescheduled = 3;
    const byte statusCancelled = 4;
    var query = from a in table
                from date in new[] { a.AppointSet.Date, a.AppointResolved.Date }
                where a.UserID == TheUserID
                   && date.Year == TheDate.Year
                   && date.Month == TheDate.Month
                group a by date into g
                orderby g.Key
                let set = g.Distinct()
                select new
                {
                    Date = g.Key,
                    Set = set.Count(a => a.AppointSet == g.Key),
                    Attended = set.Count(a => a.AppointResolved == g.Key && a.AppointStatus == statusAttended),
                    Rescheduled = set.Count(a => a.AppointResolved == g.Key && a.AppointStatus == statusRescheduled),
                    Cancelled = set.Count(a => a.AppointResolved == g.Key && a.AppointStatus == statusCancelled),
                };

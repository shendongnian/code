    const byte statusAttended = 2;
    const byte statusRescheduled = 3;
    const byte statusCancelled = 4;
    var query = from a in MyDC.LeadsAppointments.AsEnumerable()
                from date in new[] { a.AppointSet.Date, a.AppointResolved.Date }
                where a.UserID == TheUserID
                   && date.Year == TheDate.Year
                   && date.Month == TheDate.Month
                group a by date into g
                orderby g.Key
                let set = g.Distinct().ToList()
                select new ViewMonthlyActivityModel
                {
                    ViewDate = g.Key,
                    CountTotalSetOnDay =
                        set.Count(a => a.AppointSet.Date == g.Key),
                    CountTotalAttendedOnDay =
                        set.Count(a => a.AppointResolved.Date == g.Key
                                    && a.AppointStatus == statusAttended),
                    CountTotalRescheduledOnDay =
                        set.Count(a => a.AppointResolved.Date == g.Key
                                    && a.AppointStatus == statusRescheduled),
                    CountTotalCancelledOnDay =
                        set.Count(a => a.AppointResolved.Date == g.Key
                                    && a.AppointStatus == statusCancelled),
                };

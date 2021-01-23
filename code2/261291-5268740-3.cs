    const byte statusAttended = 2;
    const byte statusRescheduled = 3;
    const byte statusCancelled = 4;
    var query = from a in MyDC.LeadsAppointments
                let setDate = from aa in MyDC.LeadsAppointments
                              where aa.AppointID == a.AppointID
                              select aa.AppointSet.Date
                let resolvedDate = from aa in MyDC.LeadsAppointments
                                   where aa.AppointID == a.AppointID
                                   select aa.AppointResolved.Date
                from date in setDate.Concat(resolvedDate)
                where a.UserID == TheUserID
                   && date.Year == TheDate.Year
                   && date.Month == TheDate.Month
                group a by date into g
                orderby g.Key
                let set = g.Distinct()
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

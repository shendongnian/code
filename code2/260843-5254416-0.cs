            var userAppoints = from appnt in MyDC.LeadsAppointments
                               where appnt.UserID == TheUserID
                               select appnt;
            var appntSets = from appnt in userAppoints
                            where appnt.AppointSet.Year == TheDate.Year && appnt.AppointSet.Month == TheDate.Month
                            group appnt by appnt.AppointSet
                            into groups
                            select new ViewMonthlyActivityModel()
                                {
                                    ViewDate = groups.Key,
                                    CountTotalSetOnDay = groups.Count()
                                };
            var appntAttends = from appnt in userAppoints
                               where appnt.AppointAttended != null && appnt.AppointAttended.Value.Year == TheDate.Year && appnt.AppointAttended.Value.Month == TheDate.Month
                               group appnt by appnt.AppointAttended.Value
                               into groups
                               select new ViewMonthlyActivityModel()
                                   {
                                       ViewDate = groups.Key,
                                       CountAttendedOnDay = groups.Count()
                                   };
            var allModels = appntSets.Concat(appntAttends).GroupBy(a => a.ViewDate, (date, models) => new ViewMonthlyActivityModel 
            { 
                ViewDate = date, 
                CountTotalSetOnDay = models.Aggregate(0, (seed, model) => seed + model.CountTotalSetOnDay), 
                CountAttendedOnDay = models.Aggregate(0, (seed, model) => seed + model.CountAttendedOnDay) 
            });

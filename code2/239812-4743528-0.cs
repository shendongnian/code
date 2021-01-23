    var MyQuery = from h in MyDC.HarvestTable
                  where h.UserID == TheUserID
                  && h.HarvestDate.Month == TheMonth.Month
                  && h.HarvestDate.Year == TheMonth.Year
                  group h by h.HarvestDate.Day into g
                  select new
                  {
                      TheDay = g.Key,
                      TheDayCount = g.Count()
                  };

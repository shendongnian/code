    var topRiders = from rider in _riderDataProvider.GetAll()
                    select new {
                       Rider = rider,
                       TotalTime = (from session in rider.Sessions
                         from lap in session.Laps
                         select lap.LapTime.TotalSeconds)
                         .Sum(),
                    }
    
    var result = topRiders.OrderByDescending(r=>r.TotalTime)
                          .Select(r=>r.Rider)
                          .Take(10).ToArray();

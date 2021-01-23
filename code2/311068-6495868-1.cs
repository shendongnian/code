    var test = _dataContext.GetTable<Car>
                           .Select(c => 
                               c.MechanicVisits
                                .Select(m => m.ServiceRecord)
                                .Select(s => (DateTime?) s.ServiceDate)
                                .OrderByDescending(d => d)
                                .FirstOrDefault()
                           ).ToList();

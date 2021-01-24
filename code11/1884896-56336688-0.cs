    DateTime filterDate = DateTime.Now;
    var myData = db.Meters
                   .Select(m => new 
                                { 
                                    Meter = m, 
                                    Readings = m.Readings.Where(r => r.Date == filterDate)
                                })
                   .ToList();

    var sums = dc.Deliveries
                 .Where(d => d.TripDate == DateTime.Now
                 .GroupBy(d => d.TripDate)
                 .Select(g =>
                     new
                     {
                         Rate = g.Sum(s => s.Rate),
                         AdditionalCharges = g.Sum(s => s.AdditionalCharges)
                     });

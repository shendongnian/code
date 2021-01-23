    var customerList = from cm in dc.ConsignmentMarginBreakdowns
                       join tm in dc.ConsignmentTripBreakdowns on new { Depot = cm.Depot, TripNumber = cm.TripNumber, TripDate = cm.TripDate } equals new { Depot = tm.Depot, TripNumber = tm.TripNumber, TripDate = tm.TripDate }
                       join sl in dc.SageAccounts on new { LegacyID = cm.Customer, Customer = true } equals new { LegacyID = sl.LegacyID, Customer = sl.Customer }
                       join ss in dc.SageAccounts on sl.ParentAccount equals ss.ID
                       where (tm.DeliveryDate >= dateRange1.FromDate && tm.DeliveryDate <= dateRange1.ToDate) || (dateRange2.FromDate != null && (tm.DeliveryDate >= dateRange2.FromDate && tm.DeliveryDate <= dateRange2.ToDate))
                       where tm.Depot == depotLetter
                       group new { cm, tm } by new { ss.Name, ss.ID } into cmg
                       select new
                       {
                           CustomerID = cmg.Key.ID,
                           CustomerName = cmg.Key.Name,
                           Sales1 = cmg.Where(a => a.tm.DeliveryDate >= dateRange1.FromDate && a.tm.DeliveryDate <= dateRange1.ToDate).Sum(a => a.cm.TripSalesTotal),
                           Sales2 = dateRange2.FromDate != null ? tmg.Where(a => a.tm.DeliveryDate >= dateRange2.FromDate && a.tm.DeliveryDate <= dateRange2.ToDate).Sum(a => a.cm.TripSalesTotal) : 0.00m
                       };

    var minDate = new DateTime(2009, 1, 1);
    var query = from order in db.Orders
                where order.Date >= minDate
                group order by new { order.Vendor, 
                                     order.Date.Month, order.Date.Year } into g
                select new { g.Key.Vendor, g.Key.Month, g.Key.Year,
                             g.Sum(x => x.Amount) };

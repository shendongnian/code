    DataTable dt2 = dt.AsEnumerable()
        .GroupBy(r => new { Number = r["Number"], Type = r["Type"], Order = r["Order"] })
        .Select(g =>
        {
            var row = dt.NewRow();
    
            row["Number"] = g.Key.Number;
            row["Type"] = g.Key.Type;
            row["Order"] = g.Key.Order;
            row["Count"] = g.Count();
    
            return row;
    
        }).CopyToDataTable();

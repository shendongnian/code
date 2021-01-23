    var query = (from t in context.TestData
      group h by new { DataTypeID = h.DataTypeID, Name = h.Name } into g
      select new
     {
       DataTypeID = g.Key.DataTypeID,
       Name = g.Key.Name,
       DataValues = String.Join(",", g),
     }).ToList()

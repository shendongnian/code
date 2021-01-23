    var qs = (from t in context.TestData
      group h by new { DataTypeID = h.DataTypeID, Name = h.Name } into g
      select new
     {
       DataTypeID = g.Key.DataTypeID,
       Name = g.Key.Name,
       DataValues = g
     }).ToArray();
    var query = (from q in qs
                select new
                {
                    q.DataTypeID,
                    q.Name,
                    DataValues = String.Join(",", q.DataValues),
                }).ToList();

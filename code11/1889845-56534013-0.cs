    DataTable dt = dtrec.AsEnumerable()
        .GroupBy(r => r.Field<decimal>("ID"))
         .Select(g =>
         {
             var row = dtrec.NewRow();
             row["COL1"] = g.Sum(r => r.Field<decimal>("COL1"));
             row["ID"] = g.Key;
             row["AMT"] = g.Sum(r => r.Field<decimal>("AMT"));
             row["PERCENTAGE"] = g.Sum(r => r.Field<decimal>("PERCENTAGE"));
             row["COL4"] = g.Sum(r => r.Field<decimal>("COL4"));
             return row;
         }).CopyToDataTable();

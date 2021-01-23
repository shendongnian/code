            var datasource = from r1 in table1.AsEnumerable().Select((r, i) => new { Value = r, Index = i })
                             from r2 in table2.AsEnumerable().Select((r, i) => new { Value = r, Index = i })
                             where r1.Index == r2.Index 
                             select new
                             {
                                 col1 = r1.Value["col1"].ToString(),
                                 col2 = r1.Value["col2"].ToString(),
                                 col3 = r2.Value["col1"].ToString(),
                             };

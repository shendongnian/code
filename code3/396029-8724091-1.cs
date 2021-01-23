    var exclude = dt2.AsEnumerable()
                     .Select(r => r.Field<string>("Country"));
    
    var dt3 = dt1.AsEnumerable()
                 .Where(r => !exclude.Contains(r.Field<string>("Country")))
    			 .CopyToDataTable();

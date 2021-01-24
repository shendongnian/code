    DataTableA= DataTableB.AsEnumerable()
               .GroupBy(r => r.Field<double>("IDNumber"))
               .Select(g =>
               {
                   var row = DtSet.NewRow();
                   row["IDNumber"] = g.Key;
                   row["Value"] = g.Sum(r => r.Field<dynamic>("Value"));                   
                   return row;
               }).CopyToDataTable();

    var result = from theRow in dtTable.DataSet.Tables[0].AsEnumerable()
                     group theRow by new
                     {
                         theRow = theRow.Field<string>("category")//Group by category.
                     } into Group
                     select new
                     {
                         Row = Group.Key.theRow,
                         Count = Group.Count(),
                         Average = Group.Average(row => Decimal.Parse(row.Field<string>("performance"))),
                         UniqueRows = (from p in Group
                                       select p.Field<string>("performance")).Distinct().Count()
                     };

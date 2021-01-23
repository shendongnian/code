    var objectTable = new DataTable();
    objectTable.Columns.Add("resource_name",typeof(string));
    objectTable.Columns.Add("day_date",typeof(DateTime));
    objectTable.Columns.Add("actual_hrs",typeof(decimal));
    objectTable.Rows.Add(1, DateTime.Today, 1);
    objectTable.Rows.Add(2, DateTime.Today, 2);
    
    var newSort = from row in objectTable.AsEnumerable()
                group row by new {ID = row.Field<string>("resource_name"), time1 = row.Field<DateTime>("day_date")} into grp
                select new
                    {
                        resource_name1 = grp.Key.ID,
                        day_date1 = grp.Key.time1,
                        Sum = grp.Sum(r => r.Field<Decimal>("actual_hrs"))
                    };
    newSort.Dump();

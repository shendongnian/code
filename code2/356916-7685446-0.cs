                DataTable source = ds.Tables["source"];
                DataTable chart = ds.Tables["chart"];
                var joinedTable =
                    from s in source.AsEnumerable()
                    join c in chart.AsEnumerable()
                    on s.Field<Int64>("intRowId") equals
                        c.Field<Int64>("intItemId")
                    select new
                    {
                        intRowId = s.Field<Int64>("intRowID"),
                        strTitle = s.Field<string>("strTitle"),
                        intWeight = c.Field<Int64>("intWeight")
                    };
                var sortedTable = from j in joinedTable
                                  orderby j.intWeight descending
                                  select j;

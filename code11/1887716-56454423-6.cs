                var query =
                    from ae in a.AsEnumerable()
                    join be in b.AsEnumerable() on ae.Field<int>("ID") equals be.Field<int>("ID_") into aebe
                    from be2 in aebe.DefaultIfEmpty()
                    select new Dictionary<string, object>
                    {
                        {"ID", ae.Field<int>("ID")},
                        {"Name", ae.Field<string>("Name") },
                        {"Age", ae.Field<int>("Age") },
                        {"Address", be2?.Field<string>("Address") },
                        {"YearsAt", be2?.Field<int>("YearsAt") }
                    };
                //setup datatable
                DataTable c = new DataTable();                    
                int keyCount = query.First().Keys.Count; //track columns needed to be added
                foreach (var dict in query)
                {
                    var ro = c.NewRow();
                    foreach (string key in dict.Keys)
                    {
                        if (keyCount > 0 && dict[key] != null && !c.Columns.Contains(key))
                        { //if the column is not in the table, and the value isnt null (so we can deduce the type)
                            c.Columns.Add(key, dict[key].GetType());
                            keyCount--; //mark it as added. Eventually this will hit 0 and we won't evaluate the other two clauses
                        }
                        if (dict[key] != null) //don't store nulls
                            ro[key] = dict[key];
                    }
                    c.Rows.Add(ro);
                } 

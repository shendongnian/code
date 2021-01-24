                 var query =
                    from ae in a.AsEnumerable()
                    join be in b.AsEnumerable() on ae.Field<int>("ID") equals be.Field<int>("ID_") into aebe
                    from be2 in aebe.DefaultIfEmpty()
                    select MapToDict(ae, be2);
                //setup datatable
                DataTable c = new DataTable();                    
                int keyCount = query.First().Keys.Count;
                foreach (var dict in query)
                {
                    //have we got all our columns addded yet?
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

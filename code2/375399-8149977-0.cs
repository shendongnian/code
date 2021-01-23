    //setup
    DataTable dt = new DataTable();
    dt.Columns.Add("Group", typeof(int));
    dt.Columns.Add("Item", typeof(int));
    
    dt.Rows.Add(1, 1);
    dt.Rows.Add(1, 2);
    dt.Rows.Add(2, 3);
    dt.Rows.Add(2, 4);
    // transforms the datatable to an IEnumerable of an anonymous type
    // that contains a Group and Item properties
    var dataObjects = from row in dt.AsEnumerable()
       select new { Group = row["Group"], Item = row["Item"] };
    //after that it's just a group by application
    var groups = from row in dataObjects
                   group row by row.Group into g
                   select new Group{ GroupID = g.Key
                                    ,Items = g.Select(i => i.Item)};

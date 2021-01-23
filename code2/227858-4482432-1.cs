            var table = new DataTable();
    
            table.Columns.Add("id", typeof(int));
            table.Columns.Add("name");
            table.Columns.Add("unit");
    
            var table2 = new DataTable();
            table2.Columns.Add("id", typeof(int));
            table2.Columns.Add("value");
    
            table.Rows.Add(1, "a Name", "a Unit");
            table.Rows.Add(2, "other", "other");
    
            table2.Rows.Add(1, "value");
            table2.Rows.Add(4, "other");
            
            var result = table.AsEnumerable().Join(table2.AsEnumerable(), r1 => r1.Field<int>("id"), r2 => r2.Field<int>("id"),
                                      (r1, r2) => new {Id = r1.Field<int>("id"), Value = r2.Field<string>("value") }).ToList();
    
            foreach (var r in result)
                Console.WriteLine(r.Id + "|"+ r.Value);

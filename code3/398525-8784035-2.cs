    DataSet ds = new DataSet();
    ds.ReadXml(file);
     if (ds.Relations.Count == 2)
      {
         DataTable first = ds.Relations[0].ChildTable;
         DataTable second = ds.Relations[0].ChildTable;
    
         Console.WriteLine("Table  : " + ds.Relations[0].ParentTable.TableName);
         foreach (DataRow  row in first.Rows)
           Console.WriteLine(row["controlID"] + " " + row["rolesEnabled"] + " " + row["rolesVisible"]);
     }

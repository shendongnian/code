    ...
    string insertText = "INSERT INTO Data (ID,RAW) VALUES( ? , ? )";  // (1)
    
    SQLiteTransaction trans = conn.BeginTransaction();
    command.Transaction = trans;
    
    command.CommandText = insertText;
    //(2)------
       SQLiteParameter p0 = new SQLiteParameter();
       SQLiteParameter p1 = new SQLiteParameter();
       command.Parameters.Add(p0);
       command.Parameters.Add(p1);
    //---------
    Stopwatch sw = new Stopwatch();
    sw.Start();
    using (CsvReader csv = new CsvReader(new StreamReader(@"C:\Data.txt"), false))
    {
       var f = csv.Select(x => new Data() { IDData = x[27], RawData = String.Join(",", x.Take(24)) });
    
       foreach (var item in f)
       {
          //(3)--------
             p0.Value = item.IDData;
             p1.Value = item.RawData;
          //-----------
          command.ExecuteNonQuery();
       }
     }
     trans.Commit();
    ...

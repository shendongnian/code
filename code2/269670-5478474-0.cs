    public IEnumerable<string> GetLines()
    {
        Database db = DatabaseFactory.CreateDatabase("connectionStringKey");
        using (var command = db.GetStoredProcCommand("getdata_sp"))
        {
            var reader = db.ExecuteReader(command);
            for (var i = 0; i < 2; i++) 
            {  
              foreach(var cur in GetInnerEnumerable(reader))
              {
                yield return cur;
              }
              reader.NextResult();
            }
        }
    }

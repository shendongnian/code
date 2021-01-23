    function DataTable GetData(string tableName)
    {
      //Supposing 0th table is mapping table with 2 columns, One contains Name and another   position
       var pos = ds.Tables[0].where(x => x[0] == tableName).Select(x => x[1]).firstOrDefault();
       var table = ds.Tables[pos];
       return table;
    }

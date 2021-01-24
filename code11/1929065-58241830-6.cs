`
    const string DiffColumnName = "Column Name";
    const string DiffTable1Value = "Value From Table 1";
    const string DiffTable2Value = "Value From Table 2";
    static private DataTable GetDifferentRecords(DataTable dataTable1,
                                                 DataTable dataTable2,
                                                 string keyIDName,
                                                 string tableName)
    {
      var result = new DataTable(tableName);
      if ( dataTable1.Columns.Count != dataTable2.Columns.Count )
        throw new Exception("Tables have not the same columns count.");
      for ( int indexColumn = 0; indexColumn < dataTable1.Columns.Count; indexColumn++ )
      {
        string columnName1 = dataTable1.Columns[indexColumn].ColumnName;
        string columnName2 = dataTable2.Columns[indexColumn].ColumnName;
        if ( columnName1 != columnName2 )
          throw new Exception($"Tables columns name mismatch : {columnName1} <=> {columnName2}");
        var columnType1 = dataTable1.Columns[indexColumn].DataType;
        var columnType2 = dataTable2.Columns[indexColumn].DataType;
        if ( columnType1 != columnType2 )
          throw new Exception($"Tables columns type mismatch : {columnType1.Name} <=> {columnType2.Name}");
        if ( dataTable1.Columns[indexColumn].ColumnName == keyIDName )
        {
          result.Columns.Add(keyIDName, columnType1);
          result.Columns.Add(DiffColumnName, typeof(string));
          result.Columns.Add(DiffTable1Value, typeof(object));
          result.Columns.Add(DiffTable2Value, typeof(object));
        }
      }
      for ( int indexRow = 0; indexRow < dataTable1.Rows.Count; indexRow++ )
      {
        object columnKeyValue = null;
        for ( int indexColumn = 0; indexColumn < dataTable1.Columns.Count; indexColumn++ )
          if ( dataTable1.Columns[indexColumn].ColumnName == keyIDName )
            columnKeyValue = dataTable1.Rows[indexRow][indexColumn].ToString();
        if ( columnKeyValue == null )
          throw new Exception($"Key not found : {keyIDName}");
        for ( int indexColumn = 0; indexColumn < dataTable1.Columns.Count; indexColumn++ )
        {
          string columnName1 = dataTable1.Columns[indexColumn].ColumnName;
          string columnName2 = dataTable2.Columns[indexColumn].ColumnName;
          var value1 = dataTable1.Rows[indexRow][indexColumn];
          var value2 = dataTable2.Rows[indexRow][indexColumn];
          if ( !value1.Equals(value2) )
          {
            var row = result.NewRow();
            row[keyIDName] = columnKeyValue;
            row[DiffColumnName] = columnName1;
            row[DiffTable1Value] = value1;
            row[DiffTable2Value] = value2;
            result.Rows.Add(row);
          }
        }
      }
      return result;
    }
`
The test:
    private static void DataTableDiffTest()
    {
      DataTable before = new DataTable("InventoryItem");
      before.Columns.Add("Id", typeof(int));
      before.Columns.Add("Name", typeof(string));
      before.Columns.Add("Age", typeof(decimal));
      before.Rows.Add(1, "Tom", 24);
      before.Rows.Add(2, "Dick", 23);
      before.Rows.Add(3, "Broad", 35);
      before.Rows.Add(4, "Anderson", 29);
      DataTable after = new DataTable("InventoryItems");
      after.Columns.Add("Id", typeof(int));
      after.Columns.Add("Name", typeof(string));
      after.Columns.Add("Age", typeof(decimal));
      after.Rows.Add(1, "Tom", 24);
      after.Rows.Add(2, "Dick", 23);
      after.Rows.Add(3, "Broad2", 31);
      after.Rows.Add(4, "Anderson", 30);
      try
      {
        var diffDataTable = GetDifferentRecords(before, after, "Id", "TableDiff");
        var diffTree = new Dictionary<object,
                                      Dictionary<string,
                                                 Tuple<object, object>>>();
        foreach ( DataRow item in diffDataTable.Rows )
        {
          var items = new Tuple<object, object>(item[DiffTable1Value], item[DiffTable2Value]);
          if ( diffTree.ContainsKey(item["Id"]) )
            diffTree[item["Id"]].Add(item[DiffColumnName].ToString(), items);
          else
          {
            var mismatch = new Dictionary<string, Tuple<object, object>>();
            mismatch.Add(item[DiffColumnName].ToString(), items);
            diffTree.Add(item["Id"], mismatch);
          }
        }
        foreach ( var item in diffTree )
        {
          Console.WriteLine($"Id({item.Key}) mismatch:");
          foreach ( var value in item.Value )
          {
            Console.Write($"  Column({value.Key.ToString()}): ");
            Console.WriteLine($"{ value.Value.Item1.ToString()} <=> { value.Value.Item2.ToString()} ");
          }
          Console.WriteLine();
        }
      }
      catch ( Exception ex )
      {
        Console.WriteLine(ex.Message);
      }
    }
The output:
    Id(3) mismatch:
      Column(Name): Broad <=> Broad2
      Column(Age): 35 <=> 31
    Id(4) mismatch:
      Column(Age): 29 <=> 30

    public static DataTable MakeTable(this List<object> o)
    {
      var data = new DataTable();
      var props = o.FirstOrDefault()?.GetType().GetProperties();
      if (props == null)
          return data;
      forEach(var p in props){
            DataColumn c = new DataColumn();
            c.DataType = p.PropertyType;
            c.ColumnName = p.PropertyName;
            // c.AutoIncrement = true; // if this is a primaryKey 
            data.Columns.Add(c);
      }
      
      forEach(var item in o){
        var row = data.NewRow();
        forEach(var p in props){
         row[p.PropertyName] = p.GetValue(item);
         }
         data.Rows.Add(row);
      }
      return data;
    }
       // now all you need is to call MakeTable
       using (SqlBulkCopy bc= new SqlBulkCopy(constr)) {
          bc.DestinationTableName = "MyPersonTable";
           try
           {
                 bc.WriteToServer(personList.MakeTable());
           }
           catch (Exception ex)
           {
                 Console.WriteLine(ex.Message);
           }
    }

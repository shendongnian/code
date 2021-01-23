    using System.Linq;
    ....
	
    using (SqlConnection dbConnection = new SqlConnection(connectionString))
    {
       dbConnection.Open();
       SqlTransaction dbTrans = dbConnection.BeginTransaction();       
       using(SqlCommand cmd = new SqlCommand("dbo.spInsertTable1", dbConnection))
       {
          cmd.CommandType = CommandType.StoredProcedure;
          cmd.Transaction = dbTrans;  
          var records = Records.Select(it =>
              new {
                 field1 = it.field1,
                 field2 = it.field2,
                 field3 = it.field3,
                 field4 = it.field4,
                 field5 = it.field5,
                 field6 = it.field6
              }).ToDataTable();
          var param  = cmd.Parameters.AddWithValue("@vals", records);
          param.TypeName = "dbo.MyRecord";
          cmd.ExecuteNonQuery();
       }
        
       dbTrans.Commit();
    }
    public DataTable ToDataTable<T>(IEnumerable<T> data)
	{
		PropertyDescriptorCollection props =
			TypeDescriptor.GetProperties(typeof(T));
        if (props == null) throw new ArgumentNullException("Table properties.");
        if (data == null) throw new ArgumentNullException("data");
        
        DataTable table = new DataTable();
        for (int i = 0; i < props.Count; i++)
        {
           PropertyDescriptor prop = props[i];
          table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
        }
        object[] values = new object[props.Count];
        foreach (T item in data)
        {
          for (int i = 0; i < values.Length; i++)
          {
	          values[i] = props[i].GetValue(item) ?? DBNull.Value;
	      }
    
    	  table.Rows.Add(values);
        }
    	
    	return table;
	}

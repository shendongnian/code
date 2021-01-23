    public DataTable LINQToDataTable<T>(IEnumerable<T> varlist)
    {
         DataTable dtReturn = new DataTable();
    
         // column names 
         PropertyInfo[] oProps = null;
    
         if (varlist == null) return dtReturn;
    
         foreach (T rec in varlist)
         {
              // Use reflection to get property names, to create table, Only first time, others 
              will follow 
              if (oProps == null)
              {
                   oProps = ((Type)rec.GetType()).GetProperties();
                   foreach (PropertyInfo pi in oProps)
                   {
                        Type colType = pi.PropertyType;
    
                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition()      
                        ==typeof(Nullable<>)))
                         {
                             colType = colType.GetGenericArguments()[0];
                         }
    
                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                   }
              }
    
              DataRow dr = dtReturn.NewRow();
    
              foreach (PropertyInfo pi in oProps)
              {
                   dr[pi.Name] = pi.GetValue(rec, null) == null ?DBNull.Value :pi.GetValue
                   (rec,null);
              }
    
              dtReturn.Rows.Add(dr);
         }
         return dtReturn;
    }

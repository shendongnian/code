    public static DataTable PropertiesToDataTable(this IEnumerable<T> source)
    {
          DataTable dt = new DataTable();
          
          var props = TypeDescriptor.GetProperties(typeof(T));
    
          foreach (PropertyDescriptor prop in props)
          {
              DataColumn dc = dt.Columns.Add(prop.Name,prop.PropertyType);
              dc.Caption = prop.DisplayName;
              dc.ReadOnly = prop.IsReadOnly;
          }
    
          foreach (T item in source)
          {
                DataRow dr = dt.Rows.NewRow();
                foreach (PropertyDescriptor prop in props)
                    dr[prop.Name] = prop.GetValue(item);
    
                dt.Rows.Add(dr);
          }
    
          return dt;     
    }

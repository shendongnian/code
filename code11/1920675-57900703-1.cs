    public static DataTable ToDataTable<T>(List<T> items)
    {
            DataTable dataTable = new DataTable(typeof(T).Name);
    
           PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
               var values = new object[Props.Length];
               for (int i = 0; i < Props.Length; i++)
               {
                   
                    values[i] = Props[i].GetValue(item, null);
               }
               dataTable.Rows.Add(values);
          }
          return dataTable;
    }

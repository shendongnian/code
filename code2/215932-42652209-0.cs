      private static T CreateItemFromRow<T>(DataRow row, IList<PropertyInfo> properties) where T : new()
       {
           T item = new T();
           foreach (var property in properties)
           {  
               if (row.Table.Columns.Contains(property.Name))
               {
               property.SetValue(item, row[property.Name], null);
               }
           }
           return item;
       }

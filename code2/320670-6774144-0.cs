    static void UpdateItemProperty<T>(T item, string columnName, object rowValue) {
      var prefixColumn=columnName.IndexOf(".")==-1 ? columnName : columnName.Split(".")[0];
      var pi = typeof(T).GetProperty(prefixColumn // Add your binding flags);
      // if pi==null then there is an error...
      if (column.ColumnName.IndexOf(".") == (-1)) { // No Nesting
        pi.SetValue(item,rowValue);
        return;
      }
      // Nesting 
      var child=pi.GetValue(item);
      if (child==null) {
            // Logic here to get childs type and create an instance then call pi.SetValue with child
      }
      var remainder=string.Join(',',columnName.Split(".").Skip(1).ToArray());
      // make your generic method info for UpdateItemProperty with pi.PropertyType into mi
      mi.Invoke(null,new object[] { child,remainder,value };
    }

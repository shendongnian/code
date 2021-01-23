    public string GetPropertyColumn<T>(string Column)
    {
       Type t = typeof(T);
            
       System.Reflection.FieldInfo fi = t.GetField(Column);
       object[] attrs = fi.GetCustomAttributes(true);
       return attrs.Count() > 0 ? "Some attributes exists" : "There is no attributes";
    }

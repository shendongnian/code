    namespace MyNamespace.Data
    {
        class Converter
        {
            public static void Fill(object LogicObject, DataRow Row)
            {
                Dictionary<string, PropertyInfo> props = new Dictionary<string,PropertyInfo>();
                foreach (PropertyInfo p in LogicObject.GetType().GetProperties())
                    props.Add(p.Name, p);
                foreach (DataColumn col in Row.Table.Columns)
                {
                    string name = col.ColumnName;
                    if (Row[name] != DBNull.Value && props.ContainsKey(name))
                    {
                        object item = Row[name];
                        PropertyInfo p = props[name];
                        if (p.PropertyType != col.DataType)
                            item = Convert.ChangeType(item, p.PropertyType);
                        p.SetValue(LogicObject, item, null);
                    }
                }
    
            }
        }
    }

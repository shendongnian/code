    Server server = new Server();
    Database database = server.Databases["ReportServer"];
    
    foreach (PropertyInfo propertyInfo in typeof(Database).GetProperties())
    {
        if (typeof(SchemaCollectionBase).IsAssignableFrom(propertyInfo.PropertyType))
        {
            SchemaCollectionBase collection = (SchemaCollectionBase)propertyInfo.GetValue(database, null);
    
            foreach (IScriptable item in collection)
            {
                PropertyInfo isSystemObjectPropertyInfo = item.GetType().GetProperty("IsSystemObject");
    
                if (isSystemObjectPropertyInfo == null || !(bool)isSystemObjectPropertyInfo.GetValue(item, null))
                {
                    Console.WriteLine("{0} is scriptable and not a system object", item);
                    // TODO: ScriptObjectCreate(item, destFolder + "\\" + item.GetType() + "\\", false);
                }
            }
        }
    }

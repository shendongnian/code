    var record = new RoleModel();
    PropertyInfo[] properties = typeof(RoleModel).GetProperties();
    foreach (PropertyInfo property in properties)
    {
        Console.Writeline(property.Name);
    }

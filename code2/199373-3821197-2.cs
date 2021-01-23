    Type colorType = typeof(System.Drawing.Color);
    // We take only static property to avoid properties like Name, IsSystemColor ...
    PropertyInfo[] propInfos = colorType.GetProperties(BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public);
    foreach (PropertyInfo propInfo in propInfos) 
    {
      Console.WriteLine(propInfo.Name);
    }

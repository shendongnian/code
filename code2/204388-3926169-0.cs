    PropertyInfo[] props = 
         obj.GetType().GetProperties(BindingFlags.Public |BindingFlags.Static);
    foreach (PropertyInfo p in props)
    {
      Console.WriteLine(p.Name);
    }

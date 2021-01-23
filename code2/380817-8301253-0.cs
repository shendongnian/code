    foreach (var item in Assembly.GetEntryAssembly().GetExportedTypes())
    {
        var obj = item.Assembly.CreateInstance(item.FullName);
        foreach (var prop in item.GetProperties())
        {
            Console.WriteLine(item.Name + "," + prop.Name + "," + prop.GetValue(obj, null));
        }
    }

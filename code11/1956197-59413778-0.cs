    var flags = System.Reflection.BindingFlags.Public  
           | System.Reflection.BindingFlags.Instance  
           | System.Reflection.BindingFlags.GetProperty;
    
    var memberInfos = typeof(TEST)
    .GetMembers(flags)
    .Where(x =>  columns.Contains(x.Name))
    .ToArray();
    
    ws.Cells["A2"].LoadFromCollection(data, ..., ..., flags, memberInfos);

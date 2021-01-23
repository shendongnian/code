    var bf = BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly;
    foreach (var item in coolList)
    {
        Type t = item.GetType();
        if (t.IsPrimitive
            || (t.GetMethod("ToString", bf, null, Type.EmptyTypes, null) != null))
        {
            Console.WriteLine(item);
        }
    }

    var runtimeTypes = new List<Type>
    {
        typeof(int),
        typeof(long)
    };
    foreach (var item in runtimeTypes)
    {
        var listType = typeof(List<>).MakeGenericType(item);
        dynamic list = Activator.CreateInstance(listType);
        list.Add(1); // Call Add() on dynamic works!
        Console.WriteLine(list[0]);
    }

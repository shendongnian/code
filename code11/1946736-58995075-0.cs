    Dictionary<Type, dynamic> generics = new Dictionary<Type, dynamic>()
    {
        {typeof(string), new List<string>() {"test"}},
        {typeof(int), new List<int>(){ 0 }}
    };
    foreach (Type genericsKey in generics.Keys)
    {
        foreach (dynamic element in generics[genericsKey])
            Console.WriteLine(element);
    }

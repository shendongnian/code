    object obj= new List<string>();
    Type type = obj.GetType();
    Type enumerable = type.GetInterfaces().FirstOrDefault(t => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>));
    if (enumerable != null)
    {
        Type listType = enumerable.GetGenericArguments()[0];
        if (listType == typeof(string))
        {
            IEnumerable<string> e = obj as IEnumerable<string>;
        }
    }

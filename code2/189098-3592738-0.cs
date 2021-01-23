    static void Main(string[] args)
    {
        string typeName = "String";
        foreach (var type in GetFullType(typeName))
        {
            Console.WriteLine(type.FullName);
        }
    }
    
    static IEnumerable<Type> GetFullType(string className)
    {
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            foreach (var type in assembly.GetTypes())
            {
                if (type.Name.Equals(className, StringComparison.OrdinalIgnoreCase))
                {
                    yield return type;
                }
            }
        }
    }

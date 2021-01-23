    [Obsolete("Fubar!", false)]
    class Foo { }
    
    [Obsolete("Fubar!")]
    class Bar { }
    
    static void Main(string[] args)
    {
        // Prints: ObsoleteAttribute(String message, Boolean error)
        PrintAttributeCtorInfo(typeof(Foo));
    
        // Prints: ObsoleteAttribute(String message)
        PrintAttributeCtorInfo(typeof(Bar));
    }
    
    private static void PrintAttributeCtorInfo(Type type)
    {
        foreach (var item in CustomAttributeData.GetCustomAttributes(type))
        {
            var parameters = item.Constructor.GetParameters();
    
            string paramsList = String.Join(
                ", ",
                parameters.Select(pi => pi.ParameterType.Name + " " + pi.Name));
    
            Console.WriteLine(
                "{0}({1})",
                item.Constructor.DeclaringType.Name,
                paramsList);
        }
    }

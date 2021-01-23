    public static IEnumerable<Type> GetBuiltInTypes()
    {
       return typeof(int).Assembly
                         .GetTypes()
                         .Where(t => t.IsPrimitive);
    }

    //using System.Linq;
    //using System.Reflection;
    public static bool IsInArrayUnkownType(object array, object obj)
    {
        Type type = array.GetType().GetElementType();
        MethodInfo contains = typeof(System.Linq.Enumerable).GetMethods().Where(m => m.Name == "Contains").First();
        MethodInfo containsUnGenericated = contains.MakeGenericMethod(new[] { type });
        object result = containsUnGenericated.Invoke(null, new object[] { array, obj });
        return (bool)result;
    }

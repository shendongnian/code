    int i = 123;
    Console.WriteLine(IsBoxed(i));    // false
    object o = 123;
    Console.WriteLine(IsBoxed(o));    // true
    IComparable c = 123;
    Console.WriteLine(IsBoxed(c));    // true
    ValueType v = 123;
    Console.WriteLine(IsBoxed(v));    // true
    int? n1 = 123;
    Console.WriteLine(IsBoxed(n1));    // false
    int? n2 = null;
    Console.WriteLine(IsBoxed(n2));    // false
    string s1 = "foo";
    Console.WriteLine(IsBoxed(s1));    // false
    string s2 = null;
    Console.WriteLine(IsBoxed(s2));    // false
    // ...
    public static bool IsBoxed<T>(T item)
    {
        return (item != null) && (default(T) == null) && item.GetType().IsValueType;
    }
    public static bool IsBoxed<T>(T? item) where T : struct
    {
        return false;
    }

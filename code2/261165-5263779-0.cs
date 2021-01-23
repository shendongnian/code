    public static void Main(string[] args) {
        var test = new { Test1 = 42, Test2 = "123", Test3 = 3.14195 };
        somethingSomething(test, t => t.Test1);
        somethingSomething(test, t => t.Test2);
        somethingSomething(test, t => t.Test3);
    }
    static void somethingSomething<TObj,TProperty>(TObj obj, Expression<Func<TObj,TProperty>> expr) {
        var accessor = GetMemberAccessor(expr, obj);
        String name = accessor.Name;
        TProperty value = accessor.Value;
        String typeName = accessor.Type.Name;
        Console.WriteLine("{0} = {1} ({2})", name, value, typeName);
    }

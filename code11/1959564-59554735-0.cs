    using System.Reflection;
    public void func()
    {
        var staticMethod = typeof(T).GetMethod("StaticMethod", BindingFlags.Public | BindingFlags.Static);
        staticMethod.Invoke(null, null);
    }

    static bool IsIt(string nameObject1, string nameObject2)
    {
        Type type1 = Type.GetType(nameObject1);
        Type type2 = Type.GetType(nameObject2);
        return type2.IsAssignableFrom(type1);
    }
    static void Main()
    {
        bool b = IsIt(typeof(Foo).FullName, typeof(FooBase).FullName);
    }

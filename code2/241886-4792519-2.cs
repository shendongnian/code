    static void Main()
    {
        var b = 123;
        // this now becomes necessary as it's the only way of getting at the metadata 
        // in a presumable safe manner
        Expression<Action> x = () => SomeMethod("a", b, "a" + b); 
        var args = GetArgs(x);
        foreach (var item in args)
        {
            Console.WriteLine("{0}: {1}", item.Key, item.Value);
        }
    }

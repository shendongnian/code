    private static readonly Dictionary<CustomEnum, Action<A>> Actions =
    {
        { CustomEnum.Foo, FooAction },
        { CustomEnum.Bar, BarAction },
        { CustomEnum.Baz, BazAction },
    };
    private static void FooAction(A a) { ... }
    private static void BarAction(A a) { ... }
    private static void BazAction(A a) { ... }
    public void DoSomething()
    {
        Actions[enumValue](this);
    }

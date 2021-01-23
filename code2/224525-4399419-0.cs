    enum MyEnum
    {
        A,
        B,
        C
    }
    private readonly Dictionary<MyEnum, Action> _handlers = new Dictionary<MyEnum, Action>
                                                            {
        {MyEnum.A,()=>Console.Out.WriteLine("Foo")},
        {MyEnum.B,()=>Console.Out.WriteLine("Bar")},
        };
    public static void ActOn(MyEnum e)
    {
        Action handler = null;
        if (_handlers.TryGetValue(e, out handler) && handler != null)
        {
            handler();
        }
    }

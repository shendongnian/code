    EnumReflector e = new EnumReflector();
    e.TheEnum = (EnumReflector.MyEnum)1234;
    if (e.TheEnum == EnumReflector.MyEnum.Option1 ||
        e.TheEnum == EnumReflector.MyEnum.Option2 ||
        e.TheEnum == EnumReflector.MyEnum.Option3)
    {
        Console.WriteLine("Value is valid");
    }
    else
    {
        Console.WriteLine("Value is invalid: {0} ({1})",
                          e.TheEnum.ToString(), (int)e.TheEnum);
    }

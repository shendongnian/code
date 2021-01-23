    int max = (int)(MyEnum.Setting1 | MyEnum.Setting2 | MyEnum.Setting3 | MyEnum.Setting4);
    for (int i = 0; i <= max; i++)
    {
        var value = (MyEnum)i;
        SomeOtherFunction(value);
    }

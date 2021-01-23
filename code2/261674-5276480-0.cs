    enum MyEnum
    {
        Invalid=0,
        Value1=1,
        Value1=2,
    }
    MyEnum dbValue = ReadEnumFromDB();
    if(dbValue == MyEnum.Invalid)
    {
       ...
    }

    enum MyEnum
    {
        Value1,
        Value2,
        Value3
    }
    ...
    var dictionary = new Dictionary<MyEnum, int[]>();
    dictionary[MyEnum.Value1] = new int[] { 1, 2, 3 };
    dictionary[MyEnum.Value3] = new int[] { 4, 5, 6 };
    dictionary[MyEnum.Value3] = new int[] { 7, 8, 9 };

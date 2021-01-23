    public enum MyEnum
    {
    	A, B, C
    }
    public static void Test()
    {
    	MyEnum x = MyEnum.C;
    	bool result = new[] { MyEnum.A, MyEnum.B, (MyEnum)42 }.Contains(x);
    }

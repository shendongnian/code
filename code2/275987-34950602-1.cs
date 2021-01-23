    private MyClass myClass;
    
    public NullableEnum<MyEnum> MyEnum
    {
        get { return this.myClass.MyEnum; }
        set { this.myClass.MyEnum = value.Value; }
    }

    [Flags] 
    public enum SomeEnum
    {
        SomeValue =  1,
        SomeValue2 = 1 << 1,
        SomeValue3 = 1 << 2,
        SomeValue4 = 1 << 3,
        All = SomeValue | SomeValue2 | SomeValue3 | SomeValue4
    }

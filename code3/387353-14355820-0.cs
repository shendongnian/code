    [Flags]
    public enum SomeEnum
    {
        SomeValue =  1,
        SomeValue2 = 1 << 1,
        SomeValue3 = 1 << 2,
        SomeValue4 = 1 << 3,
        // Do not add values after this
        Last,
        All = (Last << 1) - 3,
    }

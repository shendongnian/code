    void DoIt(MyEnum e)
    {
        if (e != MyEnum.ValueA && e != MyEnum.ValueB)
        {
            throw new ArgumentException();
        }
        // ...
    }

    public static int Foo
    {
        get => foo;
        set
        {
            if (value < 0 || value > 5)
            {
                throw new ArgumentOutOfRangeException("Some useful error message");
            }
            foo = value;
        }
    }

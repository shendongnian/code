    public static implicit operator MyEnum(int value)
    {
        switch (value)
        {
            case 0:
                return ValueA;
            case 1:
                return ValueB;
            default:
                throw new InvalidCastException();
        }
    }

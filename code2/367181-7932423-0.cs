    public Bar(int a, bool plusOrMinus) : base(a, GetValueFromPlusOrMinus(plusOrMinus)) {
    }
    public static int GetValueFromPlusOrMinus(bool plusOrMinus) 
    {
        if (plusOrMinus)
            return 5;
        else
            return -5;
    }

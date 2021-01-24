    static int Multiply(int a, int b)
    {
        bool isNegative = a > 0 ^ b > 0;
        int aPositive = Math.Abs(a);
        int bPositive = Math.Abs(b);
        int result = 0;
        for(int i = 0; i < aPositive; ++i)
        {
            result += bPositive;
        }
        if (isNegative) {
            result = -result;
        }
        return result;
    }

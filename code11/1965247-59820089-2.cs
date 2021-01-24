    public static int StringToInteger(string value)
    {
        int sign = 1;
        int i = 0;
        if (value[0] == '-')
        {
            sign = -1;
            ++i;
        }
        int number = 0;
        for (; i < value.Length; ++i)
        {
            var character = value[i];
            number = (number << 1) + (number << 3) + (character - '0');
        }
        return sign * number;
    }

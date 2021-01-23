    static decimal CountDecimalPlaces(decimal dec)
    {
        int[] bits = Decimal.GetBits(dec);
        int exponent = bits[3] >> 16;
        int result = exponent;
        long lowDecimal = bits[0] | (bits[1] >> 8);
        while ((lowDecimal % 10) == 0)
        {
            result--;
            lowDecimal /= 10;
        }
        return result;
    }
    static void Foo()
    {
        Console.WriteLine(CountDecimalPlaces(1.6m));
        Console.WriteLine(CountDecimalPlaces(1.600m));
        Console.WriteLine(CountDecimalPlaces(decimal.MaxValue));
        Console.WriteLine(CountDecimalPlaces(1m * 0.00025m));
        Console.WriteLine(CountDecimalPlaces(4000m * 0.00025m));
    }

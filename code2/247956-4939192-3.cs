    static bool TryConvertToInt32(double value, out int result)
    {
        const double Min = int.MinValue - 0.5;
        const double Max = int.MaxValue + 0.5;
        // Notes:
        // 1. double.IsNaN is needed for exclusion purposes because NaN compares
        //    false for <, >=, etc. for every value (including itself).
        // 2. value < Min is correct because -2147483648.5 rounds to int.MinValue.
        // 3. value >= Max is correct because 2147483648.5 rounds to int.MaxValue + 1.
        if (double.IsNaN(value) || value < Min || value >= Max)
        {
            result = 0;
            return false;
        }
        result = Convert.ToInt32(value);
        return true;
    }

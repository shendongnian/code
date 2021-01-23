    static bool TryConvertToInt32(double value, out int result)
    {
        const double Min = int.MinValue - 0.5;
        const double Max = int.MaxValue + 0.5;
        if (double.IsNaN(value) || value < Min || value >= Max)
        {
            result = 0;
            return false;
        }
        result = Convert.ToInt32(value);
        return true;
    }

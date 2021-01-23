    /// <summary>
    /// Gets the value.
    /// </summary>
    /// <param name="number">The number.</param>
    /// <returns></returns>
    public static decimal GetValue(string number)
    {
        char unit = number.Last();
        string num = number.Remove(number.Length - 1, 1);
    
        decimal multiplier;
        switch (unit)
        {
            case 'M':
            case 'm':
                multiplier = 1000000; break;
            default:
                multiplier = 1; break;
        }
    
        return decimal.Parse(num) * multiplier;
    }

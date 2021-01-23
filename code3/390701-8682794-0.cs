    public static decimal GetValue(string number)
    {
        return decimal.Parse(number.Remove(number.Length - 1, 1)) *  _multipliers[number.Last().ToUpper()];
    }
     

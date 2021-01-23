    private string GetDecimalDigits(double d, int digitsCount)
    {
        double substracted = d - Math.Floor(d);
        return Math.Round(substracted * Math.Pow(10, digitsCount)).ToString();
    }
    
    string result = GetDecimalDigits(59.123, 2);

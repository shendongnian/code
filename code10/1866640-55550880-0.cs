    static void Main(string[] args)
    {
        string line = "11-03-1-01   |   1 | 5 000,00|1054 |P:1|KP:|RB:";
        Debug.WriteLine(GetCount(line));
        // 5000
    }
    public static int GetCount(string line)
    {
        var parts = line.Split('|');
        var temp = parts[2].Trim();
        var style = new NumberFormatInfo()
        {
            NumberDecimalSeparator=",",
            NumberGroupSeparator=" "
        };
        if (decimal.TryParse(temp,
            NumberStyles.Float | NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands, 
            style, out decimal result))
        {
            return (int)result;
        }
        return 0;
    }

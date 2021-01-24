    public static bool IsStyleValid<T>(string style, List<T> cosmetics)
    where T : IHaveId
    {
        foreach (var item in cosmetics)
        {
            var matchNumbersInDecimal = Regex.IsMatch(item.Id, "^(\\d*\\.)\\d+");
            var matchFullNumbers = Regex.IsMatch(item.Id, "^\\d+$");
            var matchNumbersWithHalfs = Regex.IsMatch(item.Id, "^[1-9][0-9]*\\/[1-9][0-9]*");
            if ((style == "decimal" && !matchNumbersInDecimal)
                || (style == "full" && !matchFullNumbers)
                || (style == "numbersWithHalfs" && !matchNumbersWithHalfs))
            {
                return false;
            }
        }
        return true;
    }

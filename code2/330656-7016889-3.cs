    static bool IsMatch(params char[] chars)
    {
        var value = chars.Where(c => c != '0').Distinct().SingleOrDefault();    
        return (value != null) || chars.All(c => c == '0');
    }

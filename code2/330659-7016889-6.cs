    static bool IsMatch(params char[] chars)
    {
        return chars.Where(c => c != '0')
                    .Distinct().Count() <= 1;    
    }

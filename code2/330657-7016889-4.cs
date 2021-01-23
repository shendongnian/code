    static bool IsMatch(char x, char y)
    {
        return x == y || x == '0' || y == '0';
    }
    
    static bool IsMatch(char a, char b, char c)
    {
        return IsMatch(a, b) && IsMatch(b, c) && IsMatch(a, c);
    }

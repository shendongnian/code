    public Boolean IsNumber(String s)
    {
        foreach (Char ch in s)
        {
            if (!Char.IsDigit(ch)) return false;
        }
        return true;
    }

    static bool TryParse(string s, out int value)        
    {
        try
        {
            value = int.Parse(s);
            return true;
        }
        catch
        {
            value = 0;
            return false;
        }
    }

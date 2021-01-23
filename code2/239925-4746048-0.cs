    bool Is1Byte(string val)
    {
        try
        {
           int num = int.Parse(text)
           return (num >= -128) && (num <= 127);
        }
        catch(Exception)
        {
            return false;
        }
    }

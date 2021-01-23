    bool Is1Byte(string val)
    {
        try
        {
           int num = int.Parse(val)
           return (num >= -128) && (num <= 127);
        }
        catch(Exception)
        {
            return false;
        }
    }

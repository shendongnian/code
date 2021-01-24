    public bool Check(string s)
    {
        bool retVal = false;
        char ch;
        totalcntupper = 0;
    
        for (char cnt = 0; cnt < s.length;cnt++)
        {
            ch = chars[cnt];
    
            if (char.IsUpper(ch))
            {              
                totalcntupper++;
            }
        }
        if (s.Length == 8 && totalcntupper == 1 && s.Any(char.IsDigit))
        {
            retVal = true;
        }
    
        return retVal;
    }

    public static bool IsSequential(string pin, bool descending)
    {
        int p = Convert.ToInt32(pin.Substring(0,1));
        string tpin = string.Empty;
    
        for (int i = 0; i < 6; i++)
        {
            tpin += descending ? (p--).ToString() : (p++).ToString();
        }
        return pin.Equals(tpin);          
    }

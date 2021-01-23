    public static bool Validate(string strNum)
    {
        bool ret = false;
        Int32 num = 0;
        if (Int32.TryParse(strNum, out num))
        {
            if (num != 99999999)
            {
                ret = true;
            }
        }
        return ret;
    }

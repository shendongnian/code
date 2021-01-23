    public static object cascadeParse(string obj)
    {
        decimal decRet;
        if (!decimal.TryParse(obj, out decRet))
        {
            int intRet;
            if (!int.TryParse(obj,  out intRet))
            {
                return obj;
            }
            else
            {
                return intRet;
            }
        }
        else
        {
            return decRet;
        }
    }

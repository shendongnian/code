    public static Boolean IsBase64(this String str)
    {
        if ((str.Length % 4) == 0)
        {
            return true;
        }
    
        //decode - encode and compare
        try
        {
            string decoded = System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(str));
            string encoded = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(decoded));
            if (str.Equals(encoded, StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }
        }
        catch { }
        return false;
    }

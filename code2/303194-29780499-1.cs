    public static bool IsBase64String1(string value)
            {
                if (string.IsNullOrEmpty(value))
                {
                    return false;
                }
                try
                {
                    Convert.FromBase64String(value);
                    if (value.EndsWith("="))
                    {
                        value = value.Trim();
                        int mod4 = value.Length % 4;
                        if (mod4 != 0)
                        {
                            return false;
                        }
                        return true;
                    }
                    else
                    {
    
                        return false;
                    }
                }
                catch (FormatException)
                {
                    return false;
                }
            }

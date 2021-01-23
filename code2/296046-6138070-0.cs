    public static bool IsNumber(String str)
            {
                try
                {
                    Double.Parse(str);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

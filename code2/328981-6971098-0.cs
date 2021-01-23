    public static bool ToBool(this string theString)
        {
            bool result = false;
            bool.TryParse(theString, out result);
            return result;
                
        }

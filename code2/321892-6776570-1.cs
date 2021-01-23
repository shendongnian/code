    public static string c(string val)
        {
            try
            {
                Double result = Convert.ToDouble(val);
                return Math.Round(result, 4).ToString();
            }
            catch
            {
                return val;
            }
        }

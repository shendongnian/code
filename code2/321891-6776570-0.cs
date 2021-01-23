    public static string c(string val)
        {
            Double result;
            if (Double.TryParse(val, out result))
                return Math.Round(result, 4).ToString();
            else
                return val;
        }

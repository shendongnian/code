    public static bool ToDouble(string s, out double d)
    {
       if (s.Contains(","))
          return double.TryParse(s.Split(",")[0].Replace(".", ""), out d);
       
       return double.TryParse(s, out d);
    }

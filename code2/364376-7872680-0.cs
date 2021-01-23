    public static bool IsEmpty(this string s)
    {
      if(s == null) return true;
      return string.IsNullOrEmpty(s);
    }

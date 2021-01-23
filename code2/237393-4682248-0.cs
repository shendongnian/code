    public static class EmailTester
    {
      static readonly Regex _regex=new Regex(...);
    
      public static bool Test(string value)
      {
        return _regex.IsMatch(value);
      }
    }

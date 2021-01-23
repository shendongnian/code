    public static class MyStringExtensions
    {
      public static string ConvertWhitespacesToSingleSpaces(this string value)
      {
        return Regex.Replace(value, @"\s+", " ");
      }
    }
    // usage: 
    string s = "test   !";
    s = s.ConvertWhitespacesToSingleSpaces();

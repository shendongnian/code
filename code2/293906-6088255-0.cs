    public static class StringExtensions
    {
      public static string[] TwoParts(this String str, char splitCharacter)
      {
        int splitIndex = str.IndexOf(splitCharacter);
        if(splitIndex == -1)
          throw new ArgumentException("Split character not found.");
    
        return new string[] {
          str.SubString(0, splitIndex),
          str.SubString(splitIndex, myString.Lenght) };
      }
    }

    class Test {
      static Regex TextRegex = new Regex(...);
      public static bool TestString(string input) {
        return Test.TextRegex.IsMatch(input);
      }
    }

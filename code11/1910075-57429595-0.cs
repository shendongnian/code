      // this method change W wild-card character to a character that match anything
      private static bool MatchToString(string stringToMatch, string pattern) {
          Regex r = new Regex(pattern.Replace("W", "."));
          return r.Match(stringToMatch).Success;
      }
      static void Main() {
      // these are matches
      Console.WriteLine(MatchToString("HHH", "HWW"));
      Console.WriteLine(MatchToString("HHH", "HHW"));
      Console.WriteLine(MatchToString("WWW", "WWW"));
      Console.WriteLine(MatchToString("HHWH", "WWWW"));
      //these are doesn't
      Console.WriteLine(MatchToString("HHH", "HHK"));
      Console.WriteLine(MatchToString("HHH", "HKK"));
      Console.WriteLine(MatchToString("WWW", "ABC"));
      Console.ReadLine();
    }

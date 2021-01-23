    public static IEnumerable<string> GetCombinations(string str) {
      for (int i = 1; i < str.Length; i++) {
        foreach (string s in GetCombinations(str.Substring(i))) {
          yield return str.Substring(0, i) + "." + s;
        }
      }
      yield return str;
    }

    string[] strings = { "a", "aa", "aaa", "b", "bb", "bbb", "c", "cc", "ccc" };
    List<string> results = new List<string>(strings);
    
    foreach (string str1 in strings) {
      foreach (string str2 in strings) {
        if (str1 != str2) {
          if (str2.Contains(str1)) {
            results.Remove(str2);
          }
        }
      }
    }
    return results;

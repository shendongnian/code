    public static bool ScrambledEquals<T>(IEnumerable<T> list1, IEnumerable<T> list2) {
      var cnt = new Dictionary<T, int>();
      foreach (T s in list1) {
        if (cnt.ContainsKey(s)) {
          cnt[s]++;
        } else {
          cnt.Add(s, 1);
        }
      }
      foreach (T s in list2) {
        if (cnt.ContainsKey(s)) {
          cnt[s]--;
        } else {
          return false;
        }
      }
      return cnt.Values.All(c => c == 0);
    }

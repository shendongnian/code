    public static class MyExtensions {
      public static ArrayList ToArrayList<T>(this IEnumerable<T> input) {
        var col = input as ICollection;
        if (col != null) {
          return new ArrayList(col);
        }
        var res = new ArrayList();
        foreach (var item in input) {
          res.Add(item);
        }
        return res;
      }
    }

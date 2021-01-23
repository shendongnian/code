    public static int Search<T>(T[] space, T[] searched) {
      foreach (var e in Array.FindAll(space, e => e.Equals(searched[0]))) {
        var idx = Array.IndexOf(space, e);
    	if (space.ArraySkip(idx).Take(searched.Length).SequenceEqual(searched))
    	  return idx;
      }
      return -1;
    }
    public static class Linqy {
      public static IEnumerable<T> ArraySkip<T>(this T[] array, int index) {
        for (int i = index;  i < array.Length; i++) {
    	  yield return array[i];
    	}
      }
    }

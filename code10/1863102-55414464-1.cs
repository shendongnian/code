    public class MyListComparer<T> : IEqualityComparer<List<T>> {
      public bool Equals(List<T> x, List<T> y) {
        return Enumerable.SequenceEqual(x, y);
      }
      public int GetHashCode(List<T> obj) {
        return obj == null ? -1 : obj.Count;
      }
    }

    public class MyLeanListComparer<T> : IEqualityComparer<List<T>> where T : IComparable<T> {
      public bool Equals(List<T> x, List<T> y) {
        if (ReferenceEquals(x, y))
          return true;
        else if (null == x || null == y)
          return false;
        return Enumerable.SequenceEqual(x.OrderBy(item => item), y.OrderBy(item => item));
      }
      public int GetHashCode(List<T> obj) {
        return obj == null ? -1 : obj.Count;
      }
    }

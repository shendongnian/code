    public class MySiteEqualityComparer : IEqualityComparer<Site> {
      public bool Equals(Site x, Site y) {
        if (ReferenceEquals(x, y))
          return true;
        else if (null == x || null == y)
          return false;
        else if (x.RouteId != y.RouteId)
          return false;
        else if (x.StartMilepost <= y.StartMilepost && x.EndMilepost >= y.StartMilepost)
          return true;
        else if (y.StartMilepost <= x.StartMilepost && y.EndMilepost >= x.StartMilepost)
          return true;
        return false;
      }
      public int GetHashCode(Site obj) {
        return obj == null
          ? 0
          : obj.RouteId == null
             ? 0
             : obj.RouteId.GetHashCode();
      }
    }

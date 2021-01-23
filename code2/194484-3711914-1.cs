    class Interval {
      public int TIME_KEY { get; set; }
      public IEnumerable<Interval> CreateRangeTo(Interval other, int step) {
        for (var i = this + step; i.TIME_KEY < other.TIME_KEY; i += step) {
          yield return i;
        }
      }
      public static Interval operator +(Interval i, int step) {
        return new Interval { TIME_KEY = i.TIME_KEY + step };
      }
    }

    private static IEnumerable<Interval> CalculateMissingIntervals(IEnumerable<Interval> list, int step) {
      return list.Zip(list.Skip(1), 
        (i1, i2) => IntervalRange(i1.TIME_KEY + step, i2.TIME_KEY, step)).
        SelectMany(x => x);
    }
    private static IEnumerable<Interval> IntervalRange(int start, int end, int step) {
      for (var i = start; i < end; i += step) {
        yield return new Interval { TIME_KEY = i };
      }
    }

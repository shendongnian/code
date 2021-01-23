    public class mtCompare : IEqualityComparer<TimeMetric>
    {
      public bool Equals(TimeMetric x, TimeMetric y)
      {
        return Equals(x.MetricText, y.MetricText);
      }
      public int GetHashCode(TimeMetric obj)
      {
        return obj.MetricText.GetHashCode();
      }
    }
    ....
    list.Distinct(new mtCompare());

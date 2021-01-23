    class MyComparer : IEqualityComparer<TimeMetric>
    {
        public bool Equals(TimeMetric x, TimeMetric y)
        {
            return x.MetricText.Equals(y.MetricText);
        }
    
        public int GetHashCode(TimeMetric obj)
        {
            return obj.MetricText.GetHashCode();
        }
    }

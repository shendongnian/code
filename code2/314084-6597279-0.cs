    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false), MetadataAttribute]
    public class MetricAttribute : ExportAttribute, IMetricAttribute
    {
        public MetricAttribute(string name, string description)
            : base(typeof(IMetric))
        {
            this.MetricName = name;
            this.MetricDescription = description;
        }
        public string MetricName { get; private set; }
        public string MetricDescription { get; private set; }
    }

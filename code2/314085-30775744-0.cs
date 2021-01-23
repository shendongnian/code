    public MetricAttribute(Type contractType, string name, string description)
        : base(contractType)
    {
        this.MetricName = name;
        this.MetricDescription = description;
    }

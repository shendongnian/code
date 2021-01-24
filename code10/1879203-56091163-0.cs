    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
    internal class DisableFilterAttribute : Attribute
    {
        public DataFilter DataFilter { get; }
        public DisableFilterAttribute(DataFilter dataFilter) => DataFilter = dataFilter;
    }
    enum DataFilter
    {
        MustHaveTermId,
        SomeFilter,
        AnotherFilter
    }

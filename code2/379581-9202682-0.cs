    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    public class IndexAttribute : Attribute
    {
        public IndexAttribute(bool isUnique = false, bool isClustered = false, SortOrder sortOrder = SortOrder.Ascending)
        {
            IsUnique = isUnique;
            IsClustered = isClustered;
            SortOrder = sortOrder == SortOrder.Unspecified ? SortOrder.Ascending : sortOrder;
        }
        public bool IsUnique { get; private set; }
        public bool IsClustered { get; private set; }
        public SortOrder SortOrder { get; private set; }
        //public string Where { get; private set; }
    }

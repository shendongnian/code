    public class EnumResourceAttribute : DescriptionAttribute
    {
        public Type ResourceType { get; private set; }
        public string ResourceName { get; private set; }
        public int SortOrder { get; private set; }
        public EnumResourceAttribute(Type ResourceType,
                             string ResourceName,
                             int SortOrder)
        {
            this.ResourceType = ResourceType;
            this.ResourceName = ResourceName;
            this.SortOrder = SortOrder;
        }
    }

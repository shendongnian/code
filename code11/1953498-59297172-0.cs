    public class AccessorDescriptor
    {
        public bool IsGetter { get; }
        public bool IsSetter { get; }
        public MethodInfo MethodInfo { get; }
        public PropertyInfo PropertyInfo { get; }
        public AccessorDescriptor(MethodInfo methodInfo, PropertyInfo propertyInfo, bool isGetter, bool isSetter)
        {
            this.MethodInfo = methodInfo;
            this.PropertyInfo = propertyInfo;
            this.IsGetter = isGetter;
            this.IsSetter = isSetter;
        }
    }
	

    public class CustomPropertyDescriptor : PropertyDescriptor
    {
        private Type propertyType;
        private Type componentType;
        public CustomPropertyDescriptor(string propertyName, Type propertyType, Type componentType)
            : base(propertyName, new Attribute[] { })
        {
            this.propertyType = propertyType;
            this.componentType = componentType;
        }
        public override bool CanResetValue(object component) { return true; }
        public override Type ComponentType { get { return componentType; } }
        public override object GetValue(object component) { return 0; /* your code here to get a value */; }
        public override bool IsReadOnly { get { return false; } }
        public override Type PropertyType { get { return propertyType; } }
        public override void ResetValue(object component) { SetValue(component, null); }
        public override void SetValue(object component, object value) { /* your code here to set a value */; }
        public override bool ShouldSerializeValue(object component) { return true; }
    }

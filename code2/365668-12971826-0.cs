    class CustomPropertyDescriptor : PropertyDescriptor
    {
        PropertyInfo propertyInfo;
        public CustomPropertyDescriptor(PropertyInfo propertyInfo)
            : base(propertyInfo.Name, Array.ConvertAll(propertyInfo.GetCustomAttributes(true), o => (Attribute)o))
        {
            this.propertyInfo = propertyInfo;
        }
        public override bool CanResetValue(object component)
        {
            return false;
        }
        public override Type ComponentType
        {
            get
            {
                return this.propertyInfo.DeclaringType;
            }
        }
        public override object GetValue(object component)
        {
            return this.propertyInfo.GetValue(component, null);
        }
        public override bool IsReadOnly
        {
            get
            {
                return !this.propertyInfo.CanWrite;
            }
        }
        public override Type PropertyType
        {
            get
            {
                return this.propertyInfo.PropertyType;
            }
        }
        public override void ResetValue(object component)
        {
        }
        public override void SetValue(object component, object value)
        {
            this.propertyInfo.SetValue(component, value, null);
        }
        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }
    }

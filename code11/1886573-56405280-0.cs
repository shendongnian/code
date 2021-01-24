    public class CustomType : DynamicObject, ICustomTypeDescriptor
    {
        private readonly Dictionary<string, object> _properties = new Dictionary<string, object>();
        public AttributeCollection GetAttributes() => new AttributeCollection();
        public string GetClassName() => null;
        public string GetComponentName() => null;
        public TypeConverter GetConverter() => null;
        public EventDescriptor GetDefaultEvent() => null;
        public PropertyDescriptor GetDefaultProperty() => null;
        public object GetEditor(Type editorBaseType) => null;
        public EventDescriptorCollection GetEvents() => GetEvents(null);
        public EventDescriptorCollection GetEvents(Attribute[] attributes) => new EventDescriptorCollection(null);
        public PropertyDescriptorCollection GetProperties() => GetProperties(null);
        public object GetPropertyOwner(PropertyDescriptor pd) => this;
        public PropertyDescriptorCollection GetProperties(Attribute[] attributes) => new PropertyDescriptorCollection(_properties.Select(p => new CustomProperty(p.Key, p.Value)).ToArray());
        public override bool TryGetMember(GetMemberBinder binder, out object value) => _properties.TryGetValue(binder.Name, out value);
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            _properties[binder.Name] = value;
            return true;
        }
    }
    public class CustomProperty : PropertyDescriptor
    {
        public CustomProperty(string name, object value)
            : base(name, Array.Empty<Attribute>())
        {
            Value = value;
        }
        public object Value { get; set; }
        public override Type ComponentType => typeof(CustomType);
        public override bool IsReadOnly => false;
        public override Type PropertyType => Value != null ? Value.GetType() : typeof(object);
        public override bool CanResetValue(object component) => false;
        public override object GetValue(object component) => Value;
        public override void ResetValue(object component) => throw new NotSupportedException();
        public override void SetValue(object component, object value) => Value = value;
        public override bool ShouldSerializeValue(object component) => false;
    }

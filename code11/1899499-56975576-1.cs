    public class StripLineTypeDescriptor : CustomTypeDescriptor
    {
        ICustomTypeDescriptor original;
        public StripLineTypeDescriptor(ICustomTypeDescriptor originalDescriptor)
            : base(originalDescriptor)
        {
            original = originalDescriptor;
        }
        public override PropertyDescriptorCollection GetProperties()
        {
            return this.GetProperties(new Attribute[] { });
        }
        public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            var properties = base.GetProperties(attributes).Cast<PropertyDescriptor>().ToList();
            var tag = properties.Where(x => x.Name == "Tag").FirstOrDefault();
            var tagAttributes = tag.Attributes.Cast<Attribute>()
                .Where(x => x.GetType() != typeof(BrowsableAttribute)).ToList();
            var serializationAttribute = tagAttributes.Single(
                x => x.GetType().FullName == "System.Windows.Forms.DataVisualization.Charting.Utilities.SerializationVisibilityAttribute");
            var visibility = serializationAttribute.GetType().GetField("_visibility",
                System.Reflection.BindingFlags.NonPublic |
                 System.Reflection.BindingFlags.Instance);
            visibility.SetValue(serializationAttribute, Enum.Parse(visibility.FieldType, "Attribute"));
            tagAttributes.Add(new BrowsableAttribute(true));
            var newTag = new MyPropertyDescriptor(tag, tagAttributes.ToArray());
            properties.Remove(tag);
            properties.Add(newTag);
            return new PropertyDescriptorCollection(properties.ToArray());
        }
    }
<!---->
    public class MyPropertyDescriptor : PropertyDescriptor
    {
        PropertyDescriptor o;
        public MyPropertyDescriptor(PropertyDescriptor originalProperty,
            Attribute[] attributes) : base(originalProperty)
        {
            o = originalProperty;
            AttributeArray = attributes;
        }
        public override bool CanResetValue(object component)
        { return o.CanResetValue(component); }
        public override object GetValue(object component) => o.GetValue(component);
        public override void ResetValue(object component) { o.ResetValue(component); }
        public override void SetValue(object component, object value) { o.SetValue(component, value); }
        public override bool ShouldSerializeValue(object component) => true;
        public override AttributeCollection Attributes => new AttributeCollection(AttributeArray);
        public override Type ComponentType => o.ComponentType;
        public override bool IsReadOnly => false;
        public override Type PropertyType => typeof(string);
    }

    public class BarConverter : ExpandableObjectConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(InstanceDescriptor))
                return true;
            return base.CanConvertTo(context, destinationType);
        }
        public override object ConvertTo(ITypeDescriptorContext context, 
            CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(InstanceDescriptor))
            {
                ConstructorInfo ci = typeof(Bar).GetConstructor(new Type[] { typeof(string) });
                Bar t = (Bar)value;
                return new InstanceDescriptor(ci, new object[] { t.Text });
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
        public override object CreateInstance(ITypeDescriptorContext context, 
            IDictionary propertyValues)
        {
            if (propertyValues == null)
                throw new ArgumentNullException("propertyValues");
            object text = propertyValues["Text"];
            return new Bar((string)text);
        }
        public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
        {
            return true;
        }
    }

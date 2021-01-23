    public class MyStringConverter : StringConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            PropertyValueDisplayedAsAttribute attr = (PropertyValueDisplayedAsAttribute)context.PropertyDescriptor.Attributes[typeof(PropertyValueDisplayedAsAttribute)];
            return new StandardValuesCollection(attr.DisplayedValues);
        }
    }

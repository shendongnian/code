        public class EllevateExpandableObjectConverter : ExpandableObjectConverter
    {
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext   context, object value, Attribute[] attributes)
        {
            var propertyDescriptors =  
                base.GetProperties(context, value, attributes.OfType<ViewablePropertyAttribute>().Cast<Attribute>().ToArray());
            var result = propertyDescriptors.Cast<PropertyDescriptor>()
                .Where(pd => pd.Attributes.OfType<ViewablePropertyAttribute>().Any())
                .ToArray();
            return new PropertyDescriptorCollection(result);
        }
    }
    [ViewablePropertyAttribute]
    [TypeConverter(typeof(EllevateExpandableObjectConverter)]
    public MyComplexType MyInstance {get;set; }
